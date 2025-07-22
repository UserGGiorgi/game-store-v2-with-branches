using Azure.Core;
using FluentValidation;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Domain.Constraints;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly IValidator<BankPaymentModel> _validator;

        public BankPaymentService(
            IPdfService pdfService,
            IValidator<BankPaymentModel> validator)
        {
            _pdfService = pdfService;
            _validator = validator;
        }

        public async Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var bankModel = EnsureValidModelType(model);
            await ValidateModelAsync(bankModel);

            return await ConvertToResult(order, userId, bankModel);
        }

        private static BankPaymentModel EnsureValidModelType(IPaymentModel model)
        {
            if (model is not BankPaymentModel bankModel)
            {
                throw new ArgumentException("Invalid payment model type", nameof(model));
            }
            return bankModel;
        }

        private async Task ValidateModelAsync(BankPaymentModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Validation failed", validationResult.ToDictionary());
            }
        }
        private async Task<PaymentResult> ConvertToResult(Order order, Guid userId, BankPaymentModel bankModel)
        {
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
