using GameStore.Application.Dtos.Order;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Orders
{
    public interface IOrderService
    {
        Task<FileContentResult> ProcessBankPayment(Guid orderId);
        Task<IEnumerable<OrderResponseDto>> GetPaidAndCancelledOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(Guid orderId);
        Task<IEnumerable<OrderDetailDto>> GetCartAsync();
        Task<IEnumerable<PaymentMethodDto>> GetPaymentMethodsAsync();
        Task CloseOrderAsync(Guid orderId);
        Task<Order?> GetOpenOrderAsync();
        Task CompleteOrderAsync(Guid orderId);
        Task CancelOrderAsync(Guid orderId);
        Task UpdateOrderDetailQuantityAsync(Guid orderId, Guid productId, int quantity);

        Task DeleteOrderDetailAsync(Guid orderId, Guid productId);
        Task ShipOrderAsync(Guid orderId);
        Task AddGameToOrderAsync(Guid orderId, string gameKey);
        Task<IEnumerable<OrderResponseDto>> GetOrdersHistoryAsync();
    }
}
