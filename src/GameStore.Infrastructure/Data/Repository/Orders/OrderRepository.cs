using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Enums;
using GameStore.Domain.Interfaces.Repositories.Orders;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(GameStoreDbContext context) : base(context) { }


        public async Task<Order?> GetOpenOrderWithItemsAsync(Guid userId)
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.CustomerId == userId && o.Status == OrderStatus.Open);
        }
        public async Task<Order?> GetOpenOrderWithDetailsAsync(Guid id)
        {
            return await _context.Orders
           .Include(o => o.OrderGames)
           .FirstOrDefaultAsync(o => o.Id == id);
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

        public async Task<Order?> GetCartWithItemsAsync(Guid userId)
        {
                return await _context.Orders
                .Include(o => o.OrderGames)
                .ThenInclude(og => og.Game)
                .FirstOrDefaultAsync(o =>
                o.CustomerId == userId &&
                o.Status == OrderStatus.Open
        );
        }
        public async Task<Order?> GetOrderWithItemsAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
        public async Task<Order?> GetOpenOrderWithItemsWithLockAsync(Guid userId)
        {
            return await _context.Orders
                .FromSqlInterpolated(
                    $"SELECT * FROM Orders WITH (UPDLOCK, ROWLOCK) WHERE CustomerId = {userId} AND Status = {(int)OrderStatus.Open}")
                .Include(o => o.OrderGames)
                .AsTracking()
                .FirstOrDefaultAsync();
        }
    }
}