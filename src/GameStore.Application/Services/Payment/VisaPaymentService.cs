using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
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
    public class VisaPaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
        private readonly ILogger<VisaPaymentService> _logger;

        public VisaPaymentService(HttpClient httpClient, ILogger<VisaPaymentService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

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
                HolderName = visaModel.HolderName,
                CardNumber = visaModel.CardNumber,
                ExpiryMonth = visaModel.ExpiryMonth,
                ExpiryYear = visaModel.ExpiryYear,
                CVV = visaModel.CVV,
                Amount = total
            };
            _logger.LogInformation("Processing Visa payment for user {UserId} with amount {Amount}",
                userId, request.Amount);
            var response = await _retryPolicy.ExecuteAsync(async () =>
                await _httpClient.PostAsJsonAsync("api/payments/visa", request));

            response.EnsureSuccessStatusCode();
            return new VisaPaymentResult();
        }
    }
}
