using GameStore.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOpenOrderWithItemsAsync();
        Task<Order?> GetOpenOrderWithDetailsAsync(Guid id);
        Task<IEnumerable<Order>> GetPaidAndCancelledOrdersAsync();
        Task<Order?> GetCartWithItemsAsync();
        Task<Order?> GetOrderWithItemsAsync(Guid orderId);
        Task<IEnumerable<Order>> GetOrderHistory();
    }
}
