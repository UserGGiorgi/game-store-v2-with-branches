using FluentValidation;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces.Payment;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Orders;
using GameStore.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System.Net;
using System.Net.Http.Json;

namespace GameStore.Application.Services.Payment
{
    public class VisaPaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<VisaPaymentService> _logger;
        private readonly IValidator<VisaPaymentRequest> _validator;
        public VisaPaymentService(HttpClient httpClient,
            ILogger<VisaPaymentService> logger,
            IValidator<VisaPaymentRequest> validator)
        {
            _httpClient = httpClient;
            _logger = logger;
            _validator = validator;
        }

        public async Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var request = ParseRequest(order, model);
            await ValidateRequest(request);
            _logger.LogInformation("Processing Visa payment for user {UserId} with amount {Amount}",
                userId, request.TransactionAmount);
            await EnsureResponseValidity(request);
            return new VisaPaymentResult();
        }
        private static VisaPaymentRequest ParseRequest(Order order,IPaymentModel model)
        {
            var visaModel = (VisaPaymentModel)model;
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            return new VisaPaymentRequest
            {
                CardHolderName = visaModel.HolderName,
                CardNumber = visaModel.CardNumber,
                ExpirationMonth = visaModel.ExpiryMonth,
                ExpirationYear = visaModel.ExpiryYear,
                Cvv = int.Parse(visaModel.CVV),
                TransactionAmount = total
            };
        }
        private async Task ValidateRequest(VisaPaymentRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for payment creation: {Errors}", validationResult.Errors);
                throw new BadRequestException("Validation failed", validationResult.ToDictionary());
            }
        }
        private async Task EnsureResponseValidity(VisaPaymentRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/payments/visa", request);

            response.EnsureSuccessStatusCode();
        }
    }
}
