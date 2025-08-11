using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Interfaces.Repositories.Orders;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Orders
{
    public class OrderGameRepository : GenericRepository<OrderGame>, IOrderGameRepository
    {
        public OrderGameRepository(GameStoreDbContext context) : base(context) { }
        public async Task<OrderGame?> GetByIdWithOrderAsync(Guid id)
        {
            return await _context.OrderGames
                .Include(og => og.Order)
                .FirstOrDefaultAsync(og => og.Id == id);
        }
    }
}
