using GameStore.Application.Interfaces.Orders;
using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace GameStore.Application.Services.Orders
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CartService> _logger;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartCacheKey = "UserCart_{0}";
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(20);

        public CartService(
        IUnitOfWork unitOfWork,
        ILogger<CartService> logger,
        IHttpContextAccessor httpContextAccessor,
        IMemoryCache cache)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cache = cache;
        }

        public async Task AddToCartAsync(string gameKey)
        {
            var userId = GetCurrentUserId();
            var cacheKey = string.Format(CartCacheKey, userId);

            var order = await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync()
                ?? await CreateNewOrderAsync(userId);

            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey);
            if (game == null)
            {
                throw new NotFoundException("Game not found");
            }
            if (game.UnitInStock <= 0)
            {
                throw new BadRequestException("Game out of stock");
            }
            ArgumentNullException.ThrowIfNull(order);
            var existingItem = order.OrderGames
                .FirstOrDefault(og => og.ProductId == game.Id);

            if (existingItem != null)
            {
                if (existingItem.Quantity >= game.UnitInStock)
                    throw new BadRequestException("Not enough stock");

                existingItem.Quantity++;
            }
            else
            {
                order.OrderGames.Add(new OrderGame
                {
                    ProductId = game.Id,
                    Price = game.Price,
                    Quantity = 1,
                    Discount = game.Discount
                });
            }
            _cache.Set(cacheKey, order, _cacheDuration);
            _logger.LogInformation("Added game {GameKey} to cart", gameKey);
            await _unitOfWork.SaveChangesAsync();
        }
        private async Task<Order> CreateNewOrderAsync(Guid userId)
        {
            var order = new Order
            {
                CustomerId = userId,
                Status = OrderStatus.Open
            };
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return order;
        }
        public async Task RemoveFromCartAsync(string gameKey)
        {
            var userId = GetCurrentUserId();
            var cacheKey = string.Format(CartCacheKey, userId);

            var order = await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync() 
                ?? throw new NotFoundException("Cart is empty");

            var game = await _unitOfWork.GameRepository
                .GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            ArgumentNullException.ThrowIfNull(order);
            var cartItem = order.OrderGames
                .FirstOrDefault(og => og.ProductId == game.Id)
                ?? throw new NotFoundException("Item not in cart");

            cartItem.Quantity--;

            if (cartItem.Quantity <= 0)
            {
                order.OrderGames.Remove(cartItem);
            }
            await _unitOfWork.SaveChangesAsync();
            if (order.OrderGames.Count == 0)
            {
                _unitOfWork.OrderRepository.Delete(order);
                _cache.Remove(cacheKey);
            }
            else
            {
                _cache.Set(cacheKey, order, _cacheDuration);
            }

            _logger.LogInformation("Removed game {GameKey} ", gameKey);
        }
        public void ClearCartCache(Guid userId)
        {
            var cacheKey = string.Format(CartCacheKey, userId);
            _cache.Remove(cacheKey);
        }
        private Guid GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim =
                user?.FindFirst("userid") ??
                user?.FindFirst(ClaimTypes.NameIdentifier) ??
                user?.FindFirst("sub");

            if (userIdClaim == null)
            {
                var claims = user?.Claims
                    .Select(c => $"{c.Type}: {c.Value}");
                _logger.LogError("Missing user ID claim. Available claims: {@Claims}", claims);
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var userIdString = userIdClaim.Value;
            if (userIdString.Length == 35 && userIdString.EndsWith("00000"))
            {
                userIdString = string.Concat(userIdString.AsSpan(0, 35), "0");
            }

            if (!Guid.TryParse(userIdString, out var userId))
            {
                _logger.LogError("Invalid user ID format: {UserIdString}", userIdString);
                throw new UnauthorizedAccessException("Invalid user identity format");
            }

            return userId;
        }
    }
}
