using Azure.Core;
using FluentValidation;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
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
        private readonly int _validityDays;
        private readonly IValidator<BankPaymentModel> _validator;

        public BankPaymentService(
            IPdfService pdfService,
            IConfiguration configuration,
            IValidator<BankPaymentModel> validator)
        {
            _validityDays = configuration.GetValue<int>("PaymentSettings:BankInvoiceValidityDays");
            _pdfService = pdfService;
            _validator = validator;
        }

        public async Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var bankModel = model as BankPaymentModel;
            ArgumentNullException.ThrowIfNull(bankModel);

            var validationResult = await _validator.ValidateAsync(bankModel);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Validation failed", validationResult.ToDictionary());
            }

            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            return await Task.FromResult<PaymentResult>(new BankPaymentResult
            {
                PdfContent = _pdfService.GenerateBankInvoice(userId, order.Id, total),
                FileName = $"invoice_{order.Id}.pdf",
                ExpiryDate = bankModel.ExpiryDate
            });
        }
    }
}
