using AutoMapper;
using GameStore.Application.Dtos.Order;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;

namespace GameStore.Infrastructure.Services
{
    public class OrderService
    {
        private readonly GameStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly PdfService _pdfService;
        private readonly IPaymentMicroservice _paymentMicroservice;

        public OrderService(GameStoreDbContext context,
            IMapper mapper,
            PdfService pdfService,
            IPaymentMicroservice paymentMicroservice)
        {
            _context = context;
            _mapper = mapper;
            _pdfService = pdfService;
            _paymentMicroservice = paymentMicroservice;
        }
        public async Task<FileContentResult> ProcessBankPayment(Guid orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == orderId)
                ?? throw new NotFoundException("Order not found");

            var total = order.OrderGames.Sum(og => og.Price * og.Quantity);
            var pdfBytes = GenerateInvoice(order.CustomerId, order.Id, total);

            order.Status = OrderStatus.Paid;
            await _context.SaveChangesAsync();

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
            var orders = await _context.Orders
                .Where(o => o.Status == OrderStatus.Paid || o.Status == OrderStatus.Cancelled)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                throw new NotFoundException("Order not found");

            return _mapper.Map<OrderResponseDto>(order);
        }
        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == orderId)
                ?? throw new NotFoundException("Order not found");

            return _mapper.Map<IEnumerable<OrderDetailDto>>(order.OrderGames);
        }
        public async Task<IEnumerable<OrderDetailDto>> GetCartAsync()
        {
            var order = await _context.Orders
                .Include(o => o.OrderGames)
                .ThenInclude(og => og.Game)
                .FirstOrDefaultAsync(o =>
                    o.Status == OrderStatus.Open &&
                    o.CustomerId == Guid.Empty
                );

            if (order == null || !order.OrderGames.Any())
                return new List<OrderDetailDto>();

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
        public async Task<IBoxPaymentResultDto> ProcessIBoxPayment(Guid orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == orderId)
                ?? throw new NotFoundException("Order not found");

            // Calculate total
            var total = order.OrderGames.Sum(og => og.Price * og.Quantity);

            // Call mock microservice
            var result = await _paymentMicroservice.ProcessIBoxPaymentAsync(
                new IBoxPaymentRequest
                {
                    OrderId = orderId,
                    Amount = (decimal)total
                });

            // Update order status
            order.Status = OrderStatus.Paid;
            order.Date = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            // Return formatted response
            return new IBoxPaymentResultDto
            {
                UserId = order.CustomerId, // Use actual customer ID from order
                OrderId = order.Id,
                PaymentDate = DateTime.UtcNow,
                Sum = total
            };
        }
        public async Task ProcessVisaPayment(Guid orderId, VisaPaymentModelDto model)
        {
            var order = await _context.Orders
                .Include(o => o.OrderGames)
                .FirstOrDefaultAsync(o => o.Id == orderId)
                ?? throw new NotFoundException("Order not found");

            var total = order.OrderGames.Sum(og => og.Price * og.Quantity);

            await _paymentMicroservice.ProcessVisaPaymentAsync(new VisaPaymentRequest
            {
                CardNumber = model.CardNumber,
                HolderName = model.Holder,
                ExpiryMonth = model.MonthExpire,
                ExpiryYear = model.YearExpire,
                CVV = model.Cvv2,
                Amount = (decimal)total
            });

            order.Status = OrderStatus.Paid;
            await _context.SaveChangesAsync();
        }
    }
}
