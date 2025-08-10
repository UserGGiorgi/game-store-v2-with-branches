using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Enums;
using GameStore.Domain.Interfaces.Repositories.Orders;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(GameStoreDbContext context) : base(context) { }
    
        public async Task<Order?> GetOpenOrderWithItemsAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .ThenInclude(og => og.Game)
                .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);
        }
        public async Task<Order?> GetOpenOrderWithDetailsAsync(Guid id)
        {
            return await _context.Orders
           .Include(o => o.OrderGames)
           .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Order>> GetOrderHistory()
        {
            return await _context.Orders
                .Where(o => o.Status == OrderStatus.Shipped)
                .ToListAsync();
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
                    o.Status == OrderStatus.Open
                );
        }
        public async Task<Order?> GetOrderWithItemsAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}