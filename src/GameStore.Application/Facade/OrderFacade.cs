using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Facade
{
    public class OrderFacade : IOrderFacade
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public OrderFacade(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        public Task AddToCartAsync(string gameKey) => _cartService.AddToCartAsync(gameKey);
        public Task RemoveFromCartAsync(string gameKey) => _cartService.RemoveFromCartAsync(gameKey);
        public Task<IEnumerable<OrderDetailDto>> GetCartAsync() => _orderService.GetCartAsync();
        public Task<IEnumerable<OrderResponseDto>> GetPaidAndCancelledOrdersAsync() => _orderService.GetPaidAndCancelledOrdersAsync();
        public Task<OrderResponseDto> GetOrderByIdAsync(Guid id) => _orderService.GetOrderByIdAsync(id);
        public Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(Guid orderId) => _orderService.GetOrderDetailsAsync(orderId);
        public Task<IEnumerable<PaymentMethodDto>> GetPaymentMethodsAsync() => _orderService.GetPaymentMethodsAsync();
        public Task<Order?> GetOpenOrderAsync() => _orderService.GetOpenOrderAsync();
        public Task CloseOrderAsync(Guid orderId) => _orderService.CloseOrderAsync(orderId);
        public Task CompleteOrderAsync(Guid orderId) =>_orderService.CompleteOrderAsync(orderId);

        public Task CancelOrderAsync(Guid orderId) =>_orderService.CancelOrderAsync(orderId);
    }
}
