using GameStore.Application.Interfaces.Auth;
using GameStore.Application.Interfaces.Orders;
using GameStore.Application.Services.Auth;
using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Security.Claims;

namespace GameStore.Application.Services.Orders
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CartService> _logger;
        private readonly IUserContextService _userContextService;

        public CartService(
            IUnitOfWork unitOfWork,
            ILogger<CartService> logger,
            IUserContextService userContextService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userContextService = userContextService;
        }

        public async Task AddToCartAsync(string gameKey)
        {
            var userId = _userContextService.GetCurrentUserId();

            await using var transaction = await _unitOfWork.BeginTransactionWithIsolationAsync(IsolationLevel.Serializable);

            try
            {
                // Get existing order or create a NEW one
                var order = await _unitOfWork.OrderRepository.GetOpenOrderWithItemsWithLockAsync(userId);
                if (order == null)
                {
                    order = CreateNewOrder(userId);
                    await _unitOfWork.OrderRepository.AddAsync(order);
                }

                var game = await _unitOfWork.GameRepository.GetByKeyWithLockAsync(gameKey)
                          ?? throw new NotFoundException("Game not found");

                if (game.UnitInStock <= 0)
                    throw new BadRequestException("Game out of stock");

                var existingItem = order.OrderGames.FirstOrDefault(og => og.ProductId == game.Id);

                if (existingItem != null)
                {
                    if (existingItem.Quantity >= game.UnitInStock)
                        throw new BadRequestException("Not enough stock");

                    existingItem.Quantity++;
                }
                else
                {
                    var newOrderItem = new OrderGame
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order.Id,
                        ProductId = game.Id,
                        Price = game.Price,
                        Quantity = 1,
                        Discount = game.Discount
                    };

                    await _unitOfWork.OrderGameRepository.AddAsync(newOrderItem);

                    order.OrderGames.Add(newOrderItem);
                }

                await _unitOfWork.SaveChangesAsync();
                await transaction.CommitAsync();
                _logger.LogInformation("Added game {GameKey} to cart", gameKey);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Failed to add game {GameKey} to cart", gameKey);
                throw;
            }
        }

        private Order CreateNewOrder(Guid userId)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = userId,
                Status = OrderStatus.Open,
                OrderGames = new List<OrderGame>()
            };
        }

        public async Task RemoveFromCartAsync(string gameKey)
        {
            var userId = _userContextService.GetCurrentUserId();

            var order = await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync(userId)
                ?? throw new NotFoundException("Cart is empty");

            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            var cartItem = order.OrderGames.FirstOrDefault(og => og.ProductId == game.Id)
                ?? throw new NotFoundException("Item not in cart");

            cartItem.Quantity--;

            if (cartItem.Quantity <= 0)
            {
                order.OrderGames.Remove(cartItem);
            }

            if (!order.OrderGames.Any())
            {
                _unitOfWork.OrderRepository.Delete(order);
            }

            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Removed game {GameKey} from cart", gameKey);
        }

        //private async Task<Order> CreateNewOrderAsync(Guid userId)
        //{
        //    var order = new Order
        //    {
        //        CustomerId = userId,
        //        Status = OrderStatus.Open,
        //        OrderGames = new List<OrderGame>()
        //    };
        //    await _unitOfWork.OrderRepository.AddAsync(order);
        //    await _unitOfWork.SaveChangesAsync();
        //    return order;
        //}
    }
}