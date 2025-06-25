using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
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

        public CartService(
        IUnitOfWork unitOfWork,
        ILogger<CartService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddToCartAsync(string gameKey)
        {
            var order = await GetOrCreateOpenOrderAsync();

            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey);
            if (game == null)
            {
                throw new NotFoundException("Game not found");
            }
            if (game.UnitInStock <= 0)
            {
                throw new BadRequestException("Game out of stock");
            }
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
            _logger.LogInformation("Added game {GameKey} to cart for user {UserId}", gameKey, GetStubUserId());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string gameKey)
        {
            var order = await GetOpenOrderAsync();
            if (order == null)
            {
                throw new NotFoundException("Cart is empty");
            }
            var game = await _unitOfWork.GameRepository
                .GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            var cartItem = order.OrderGames
                .FirstOrDefault(og => og.ProductId == game.Id)
                ?? throw new NotFoundException("Item not in cart");

            cartItem.Quantity--;

            if (cartItem.Quantity <= 0)
            {
                order.OrderGames.Remove(cartItem);
            }

            if (order.OrderGames.Count() == 0)
            {
                _unitOfWork.OrderRepository.Delete(order);
            }
            _logger.LogInformation("Removed game {GameKey} from cart for user {UserId}", gameKey, GetStubUserId());
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Order> GetOrCreateOpenOrderAsync()
        {
            var order = await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync();

            if (order == null)
            {
                order = new Order
                {
                    CustomerId = GetStubUserId(),
                    Status = OrderStatus.Open
                };
                await _unitOfWork.OrderRepository.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();
            }
            return order;
        }

        private async Task<Order?> GetOpenOrderAsync()
        {
            return await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync();
        }
        private static Guid GetStubUserId()
        {
            return Guid.Parse("a5e6c2d4-1b3f-4a7e-8c9d-0f1e2d3c4b5a");
        }
    }
}
