using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Interfaces.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository.Orders
{
    public class OrderGameRepository : GenericRepository<OrderGame>, IOrderGameRepository
    {
        public OrderGameRepository(GameStoreDbContext context) : base(context) { }
    }
}
