using System.Net;
using System.Net.Http.Json;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace GameStore.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PaymentService> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public PaymentService(
            HttpClient httpClient,
            ILogger<PaymentService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            // Configure retry policy (3 retries with exponential backoff)
            _retryPolicy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r =>
                    r.StatusCode >= HttpStatusCode.InternalServerError ||
                    r.StatusCode == HttpStatusCode.RequestTimeout)
                .WaitAndRetryAsync(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (result, timespan) =>
                {
                    _logger.LogWarning($"Retrying payment. Attempt failed with: {result.Exception?.Message ?? result.Result.StatusCode.ToString()}");
                });
        }

        public async Task<IBoxPaymentResultDto> ProcessIBoxPaymentAsync(IBoxPaymentRequest request)
        {
            var response = await _retryPolicy.ExecuteAsync(async () =>
                await _httpClient.PostAsJsonAsync("api/payments/ibox", request));

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IBoxPaymentResultDto>();

            return result ?? throw new InvalidOperationException(
                "Payment microservice returned null for IBox payment result");
        }

        public async Task ProcessVisaPaymentAsync(VisaPaymentRequest request)
        {
            var response = await _retryPolicy.ExecuteAsync(async () =>
                await _httpClient.PostAsJsonAsync("api/payments/visa", request));

            response.EnsureSuccessStatusCode();
        }
    }
}
