using FluentValidation;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Payment
{
    public class BoxPaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IValidator<BoxPaymentRequest> _validator;
        private readonly ILogger<BoxPaymentService> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public BoxPaymentService(HttpClient httpClient,
            ILogger<BoxPaymentService> logger,
            IValidator<BoxPaymentRequest> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
            _logger = logger;
            _retryPolicy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r =>
                    r.StatusCode >= HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        }

        public async Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            var request = new BoxPaymentRequest
            { transactionAmount = total, accountNumber = userId, invoiceNumber = order.Id };

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for payment creation: {Errors}", validationResult.Errors);
                throw new BadRequestException("Validation failed", validationResult.ToDictionary());
            }
            var response = await _retryPolicy.ExecuteAsync(async () =>
                await _httpClient.PostAsJsonAsync("api/payments/ibox", request));

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<BoxPaymentResultDto>();
            return result == null
                ? throw new InvalidOperationException("Failed to deserialize IBox payment result")
                : (PaymentResult)new BoxPaymentResult
            {
                UserId = result.UserId,
                OrderId = result.OrderId,
                PaymentDate = result.PaymentDate,
                Sum = result.Sum
            };
        }
    }
}
