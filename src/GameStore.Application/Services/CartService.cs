using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CartService> _logger;
        private readonly IMemoryCache _cache;
        private const string CartCacheKey = "UserCart_{0}";
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(20);

        public CartService(
        IUnitOfWork unitOfWork,
        ILogger<CartService> logger,
        IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cache = cache;
        }

        public async Task AddToCartAsync(string gameKey)
        {
            var userId = GetStubUserId();
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
            _logger.LogInformation("Added game {GameKey} to cart for user {UserId}", gameKey, GetStubUserId());
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
            var userId = GetStubUserId();
            var cacheKey = string.Format(CartCacheKey, userId);

            var order = await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync();
            if (order == null) throw new NotFoundException("Cart is empty");

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

            _logger.LogInformation("Removed game {GameKey} from cart for user {UserId}", gameKey, GetStubUserId());
        }
        public void ClearCartCache(Guid userId)
        {
            var cacheKey = string.Format(CartCacheKey, userId);
            _cache.Remove(cacheKey);
        }
        private static Guid GetStubUserId()
        {
            return Guid.Parse("a5e6c2d4-1b3f-4a7e-8c9d-0f1e2d3c4b5a");
        }
    }
}
