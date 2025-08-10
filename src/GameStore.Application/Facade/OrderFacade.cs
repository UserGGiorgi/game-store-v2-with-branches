using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces.Orders;
using GameStore.Domain.Entities.Orders;

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
        public Task UpdateOrderDetailQuantityAsync(Guid orderId, Guid productId, int quantity)
        => _orderService.UpdateOrderDetailQuantityAsync(orderId, productId, quantity);
        public Task DeleteOrderDetailAsync(Guid id)
        => _orderService.DeleteOrderDetailAsync(id);
        public Task ShipOrderAsync(Guid orderId)
        => _orderService.ShipOrderAsync(orderId);
        public Task AddGameToOrderAsync(Guid orderId, string gameKey)
        => _orderService.AddGameToOrderAsync(orderId, gameKey);
        public Task<IEnumerable<OrderResponseDto>> GetOrderHistory() 
        => _orderService.GetOrderHistory();

    }
}
