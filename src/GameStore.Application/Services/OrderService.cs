using AutoMapper;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<FileContentResult> ProcessBankPayment(Guid orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderWithItemsAsync(orderId)
            ?? throw new NotFoundException("Order not found");

            var total = order.OrderGames.Sum(og => og.Price * og.Quantity);
            var pdfBytes = GenerateInvoice(order.CustomerId, order.Id, total);

            order.Status = OrderStatus.Paid;
            await _unitOfWork.SaveChangesAsync();

            return new FileContentResult(pdfBytes, "application/pdf")
            {
                FileDownloadName = $"invoice_{order.Id}.pdf"
            };
        }

        private byte[] GenerateInvoice(Guid userId, Guid orderId, double total)
        {
            using var ms = new MemoryStream();
            using var doc = new Document();
            var writer = PdfWriter.GetInstance(doc, ms);

            doc.Open();
            doc.Add(new Paragraph($"Bank Invoice"));
            doc.Add(new Paragraph($"Order ID: {orderId}"));
            doc.Add(new Paragraph($"User ID: {userId}"));
            doc.Add(new Paragraph($"Date: {DateTime.Now:yyyy-MM-dd}"));
            doc.Add(new Paragraph($"Total: {total:C}"));
            doc.Close();

            return ms.ToArray();
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

            if (order == null || !order.OrderGames.Any())
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
    }
}
