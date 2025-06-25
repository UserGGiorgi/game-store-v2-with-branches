using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Payment
{
    public class BankPaymentService : IPaymentService
    {
        private readonly IPdfService _pdfService;

        public BankPaymentService(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        public Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            return Task.FromResult<PaymentResult>(new BankPaymentResult
            {
                PdfContent = _pdfService.GenerateBankInvoice(userId, order.Id, total),
                FileName = $"invoice_{order.Id}.pdf"
            });
        }
    }
}
