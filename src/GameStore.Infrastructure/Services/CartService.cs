using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly GameStoreDbContext _context;

        public CartService(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(string gameKey)
        {
            var order = await GetOrCreateOpenOrderAsync();

            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Key == gameKey)
                ?? throw new NotFoundException("Game not found");

            if (game.UnitInStock <= 0)
                throw new BadRequestException("Game out of stock");

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

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string gameKey)
        {
            var order = await GetOpenOrderAsync()
                ?? throw new NotFoundException("Cart is empty");

            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Key == gameKey)
                ?? throw new NotFoundException("Game not found");

            var cartItem = order.OrderGames
                .FirstOrDefault(og => og.ProductId == game.Id)
                ?? throw new NotFoundException("Item not in cart");

            cartItem.Quantity--;

            if (cartItem.Quantity <= 0)
            {
                order.OrderGames.Remove(cartItem);
            }

            if (!order.OrderGames.Any())
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrCreateOpenOrderAsync()
        {
            var order = await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);

            if (order == null)
            {
                order = new Order
                {
                    CustomerId = Guid.Empty,
                    Status = OrderStatus.Open
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }

        public async Task<Order?> GetOpenOrderAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);
        }

    }
}
