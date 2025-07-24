using AutoMapper;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.Application.Services
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
            var order = await _unitOfWork.OrderRepository.GetOrderWithDetailsAsync(orderId)
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
    }
}
