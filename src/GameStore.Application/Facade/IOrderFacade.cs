using GameStore.Application.Dtos.Order;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Facade
{
    public interface IOrderFacade
    {
        Task AddToCartAsync(string gameKey);
        Task RemoveFromCartAsync(string gameKey);
        Task<IEnumerable<OrderDetailDto>> GetCartAsync();
        Task<IEnumerable<OrderResponseDto>> GetPaidAndCancelledOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(Guid orderId);
        Task<IEnumerable<PaymentMethodDto>> GetPaymentMethodsAsync();
        Task<Order?> GetOpenOrderAsync();
        Task CloseOrderAsync(Guid orderId);
        Task CompleteOrderAsync(Guid orderId);
        Task CancelOrderAsync(Guid orderId);
    }
}
