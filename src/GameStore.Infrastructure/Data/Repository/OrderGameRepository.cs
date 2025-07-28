using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
{
    public class OrderGameRepository : GenericRepository<OrderGame>, IOrderGameRepository
    {
        public OrderGameRepository(GameStoreDbContext context) : base(context) { }
    }
}
