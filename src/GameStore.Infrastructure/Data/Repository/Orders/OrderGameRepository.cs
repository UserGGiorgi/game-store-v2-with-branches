using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Interfaces.Repositories.Orders;

namespace GameStore.Infrastructure.Data.Repository.Orders
{
    public class OrderGameRepository : GenericRepository<OrderGame>, IOrderGameRepository
    {
        public OrderGameRepository(GameStoreDbContext context) : base(context) { }
    }
}
