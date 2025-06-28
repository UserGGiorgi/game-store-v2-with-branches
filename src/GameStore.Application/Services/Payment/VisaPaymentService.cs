using FluentValidation;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Payment
{
    public class VisaPaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        private readonly ILogger<VisaPaymentService> _logger;
        private readonly IValidator<VisaPaymentRequest> _validator;
        public VisaPaymentService(HttpClient httpClient,
            ILogger<VisaPaymentService> logger,
            IValidator<VisaPaymentRequest> validator)
        {
            _httpClient = httpClient;
            _logger = logger;
            _validator = validator;

            _retryPolicy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r =>
                    r.StatusCode >= HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (result, timespan) =>
                { });
        }

        public async Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var visaModel = (VisaPaymentModel)model;
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            var request = new VisaPaymentRequest
            {
                CardHolderName = visaModel.HolderName,
                CardNumber = visaModel.CardNumber,
                ExpirationMonth = visaModel.ExpiryMonth,
                ExpirationYear = visaModel.ExpiryYear,
                Cvv = int.Parse(visaModel.CVV),
                TransactionAmount = total
            };

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for payment creation: {Errors}", validationResult.Errors);
                throw new BadRequestException("Validation failed", validationResult.ToDictionary());
            }
            _logger.LogInformation("Processing Visa payment for user {UserId} with amount {Amount}",
                userId, request.TransactionAmount);
            var response = await _retryPolicy.ExecuteAsync(async () =>
                await _httpClient.PostAsJsonAsync("api/payments/visa", request));

            response.EnsureSuccessStatusCode();
            return new VisaPaymentResult();
        }
    }
}
