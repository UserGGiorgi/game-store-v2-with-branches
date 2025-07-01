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

        public BoxPaymentService(HttpClient httpClient,
            ILogger<BoxPaymentService> logger,
            IValidator<BoxPaymentRequest> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
            _logger = logger;

        }

        public async Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model)
        {
            var request = ValidateOrder(order, userId);

            var response = await _httpClient.PostAsJsonAsync("api/payments/ibox", request);

            return await ValidResponse(response);
        }
        private async Task<BoxPaymentRequest> ValidateOrder(Order order, Guid userId)
        {
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            var request = new BoxPaymentRequest
            {
                transactionAmount = total,
                accountNumber = userId,
                invoiceNumber = order.Id,
            };
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation failed for payment creation: {Errors}", validationResult.Errors);
                throw new BadRequestException("Validation failed", validationResult.ToDictionary());
            }
            return request;
        }
        private async Task<PaymentResult> ValidResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<BoxApiResponse>();
            return result == null
                ? throw new InvalidOperationException("Failed to deserialize IBox payment result")
                : (PaymentResult)new BoxPaymentResult
                {
                    UserId = Guid.Parse(result.AccountId),
                    OrderId = Guid.Parse(result.AccountId),
                    PaymentDate = DateTime.UtcNow,
                    Sum = result.Amount
                };

        }
    }
}
