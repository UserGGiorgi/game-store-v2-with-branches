using AutoMapper;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces.Orders;
using GameStore.Application.Interfaces.Pdf;
using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly IPdfService _pdfService;

        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OrderService> logger,
            IPdfService pdfService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _pdfService = pdfService;
        }
        public async Task<FileContentResult> ProcessBankPayment(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(orderId)
            ?? throw new NotFoundException("Order not found");

            var total = (decimal)order.OrderGames.Sum(og => og.Price * og.Quantity);
            var pdfBytes = _pdfService.GenerateBankInvoice(order.CustomerId, order.Id, total);

            order.Status = OrderStatus.Paid;
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Bank payment processed for order {OrderId} with total {Total}", order.Id, total);
            return new FileContentResult(pdfBytes, "application/pdf")
            {
                FileDownloadName = $"invoice_{order.Id}.pdf"
            };
        }
        public async Task<IEnumerable<OrderResponseDto>> GetPaidAndCancelledOrdersAsync()
        {
            var orders = await _unitOfWork.OrderRepository.GetPaidAndCancelledOrdersAsync();

            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Order not found");

            return _mapper.Map<OrderResponseDto>(order);
        }
        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOpenOrderWithDetailsAsync(orderId)
            ?? throw new NotFoundException("Order not found");

            return _mapper.Map<IEnumerable<OrderDetailDto>>(order.OrderGames);
        }
        public async Task<IEnumerable<OrderDetailDto>> GetCartAsync()
        {
            var order = await _unitOfWork.OrderRepository.GetCartWithItemsAsync();

            if (order == null || order.OrderGames.Count == 0)
                return [];

            return order.OrderGames.Select(og => new OrderDetailDto
            {
                ProductId = og.Game.Id,
                Price = og.Price,
                Quantity = og.Quantity,
                Discount = og.Discount
            }).ToList();
        }
        public Task<IEnumerable<PaymentMethodDto>> GetPaymentMethodsAsync()
        {
            return Task.FromResult<IEnumerable<PaymentMethodDto>>(new List<PaymentMethodDto>
        {
            new() {
                Title = "Bank",
                ImageUrl = "/assets/payment-methods/bank.png",
                Description = "Pay via bank transfer invoice"
            },
            new() {
                Title = "IBox terminal",
                ImageUrl = "/assets/payment-methods/ibox.png",
                Description = "Pay at IBox terminal"
            },
            new() {
                Title = "Visa",
                ImageUrl = "/assets/payment-methods/visa.png",
                Description = "Pay with Visa/Mastercard"
            }
        });
        }
        public async Task CloseOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId);
            if (order == null) throw new NotFoundException("Order not found");

            order.Status = OrderStatus.Paid;
            order.Date = DateTime.UtcNow;
            foreach (var item in order.OrderGames)
            {
                var game = await _unitOfWork.GameRepository.GetByIdAsync(item.ProductId);
                if (game != null)
                {
                    game.UnitInStock -= item.Quantity;
                }
            }
            _logger.LogInformation("Closing order {OrderId} with {ItemCount} items", order.Id, order.OrderGames.Count);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Order?> GetOpenOrderAsync()
        {
            return await _unitOfWork.OrderRepository.GetOpenOrderWithItemsAsync();
        }
        public async Task CompleteOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(orderId)
                ?? throw new NotFoundException("Order not found");

            order.Status = OrderStatus.Paid;
            order.Date = DateTime.UtcNow;

            foreach (var item in order.OrderGames)
            {
                var game = await _unitOfWork.GameRepository.GetByIdAsync(item.ProductId);
                if (game != null)
                {
                    game.UnitInStock -= item.Quantity;
                }
            }

            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Completed order {OrderId}", order.Id);
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId)
                ?? throw new NotFoundException("Order not found");

            order.Status = OrderStatus.Cancelled;
            order.Date = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Cancelled order {OrderId}", order.Id);
        }

        public async Task UpdateOrderDetailQuantityAsync(Guid orderId, Guid productId, int quantity)
        {
            ValidateQuantity(quantity);

            var order = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(orderId)
                ?? throw new NotFoundException("Order not found");

            if (order.Status != OrderStatus.Open)
                throw new InvalidOperationException("Cannot modify closed orders");

            var orderItem = order.OrderGames.FirstOrDefault(og =>
                og.ProductId == productId && og.OrderId == orderId)
                ?? throw new NotFoundException("Order item not found");

            orderItem.Quantity = quantity;
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation(
                "Updated quantity for product {ProductId} in order {OrderId} to {Quantity}",
                productId, orderId, quantity);
        }

        public async Task DeleteOrderDetailAsync(Guid id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Order not found");

            if (order.Status != OrderStatus.Open)
                throw new InvalidOperationException("Cannot modify closed orders");

            _unitOfWork.OrderRepository.Delete(order);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task ShipOrderAsync(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(orderId)
                ?? throw new NotFoundException("Order not found");

            if (order.Status != OrderStatus.Paid)
                throw new InvalidOperationException("Only paid orders can be shipped");

            order.Status = OrderStatus.Shipped;
            order.ShipDate = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Shipped order {OrderId}", orderId);
        }
        public async Task AddGameToOrderAsync(Guid orderId, string gameKey)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(orderId)
                ?? throw new NotFoundException("Order not found");

            if (order.Status != OrderStatus.Open)
                throw new InvalidOperationException("Cannot add items to closed orders");

            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            var existingItem = order.OrderGames.FirstOrDefault(og =>
                og.ProductId == game.Id && og.OrderId == orderId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                order.OrderGames.Add(new OrderGame
                {
                    OrderId = orderId,
                    ProductId = game.Id,
                    Price = game.Price,
                    Quantity = 1,
                    Discount = game.Discount
                });
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation(
                "Added game {GameKey} to order {OrderId}",
                gameKey, orderId);
        }
        private void ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive", nameof(quantity));
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrderHistory()
        {
            var orders = await _unitOfWork.OrderRepository.GetOrderHistory();

            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }
    }
}
