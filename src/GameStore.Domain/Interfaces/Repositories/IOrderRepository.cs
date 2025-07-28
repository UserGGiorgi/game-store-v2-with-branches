using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOpenOrderWithItemsAsync();
        Task<Order?> GetOpenOrderWithDetailsAsync(Guid id);
        Task<IEnumerable<Order>> GetPaidAndCancelledOrdersAsync();
        Task<Order?> GetCartWithItemsAsync();
        Task<Order?> GetOrderWithItemsAsync(Guid orderId);
    }
}
