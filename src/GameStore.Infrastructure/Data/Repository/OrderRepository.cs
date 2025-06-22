using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(GameStoreDbContext context) : base(context) { }
    
        public async Task<Order?> GetOpenOrderWithItemsAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);
        }
        public async Task<Order?> GetOrderWithItemsAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<IEnumerable<Order>> GetPaidAndCancelledOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid || o.Status == OrderStatus.Cancelled)
                .ToListAsync();
        }

        public async Task<Order?> GetCartWithItemsAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .ThenInclude(og => og.Game)
                .FirstOrDefaultAsync(o =>
                    o.Status == OrderStatus.Open &&
                    o.CustomerId == Guid.Empty
                );


        }

        public async Task<Order?> GetOrderWithDetailsAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}