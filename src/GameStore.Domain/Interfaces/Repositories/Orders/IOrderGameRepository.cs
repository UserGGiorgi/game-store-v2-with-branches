using GameStore.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Orders
{
    public interface IOrderGameRepository : IGenericRepository<OrderGame>
    {
        Task<OrderGame?> GetByIdWithOrderAsync(Guid id);
    }
}
