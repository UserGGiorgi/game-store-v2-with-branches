using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Facade;
using GameStore.Application.Interfaces;
using GameStore.Application.Interfaces.Payment;
using GameStore.Domain.Constraints;
using GameStore.Domain.Entities;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Payment
{
    public class PaymentProcessingService : IPaymentProcessingService
    {
        private readonly ILogger<PaymentProcessingService> _logger;
        private readonly IOrderFacade _orderFacade;
        private readonly IPaymentServiceFactory _paymentServiceFactory;
        private readonly PaymentSettings _paymentSettings;
        private readonly ICartService _cartService;

        public PaymentProcessingService(
            ILogger<PaymentProcessingService> logger,
            IOrderFacade orderFacade,
            IPaymentServiceFactory paymentServiceFactory,
            IOptions<PaymentSettings> paymentSettings,
            ICartService cartService)
        {
            _logger = logger;
            _orderFacade = orderFacade;
            _paymentServiceFactory = paymentServiceFactory;
            _paymentSettings = paymentSettings.Value;
            _cartService = cartService;
        }

        public async Task<IActionResult> ProcessPaymentAsync(Guid userId, PaymentRequestDto request)
        {
            Order? order = null;

            try
            {
                _logger.LogInformation("Processing payment for user {UserId} with method {Method}",
                    userId, request.Method);

                order = await _orderFacade.GetOpenOrderAsync();
                if (order == null || order.OrderGames.Count == 0)
                    return BadRequest("Cart is empty");

                if (request.Model == null)
                    return BadRequest("Payment model is required");

                IPaymentModel model = CreatePaymentModel(request);

                var paymentService = _paymentServiceFactory.Create(request.Method);
                var result = await paymentService.PayAsync(order, userId, model);

                await _orderFacade.CompleteOrderAsync(order.Id);
                _cartService.ClearCartCache(userId);
                _logger.LogInformation("Payment successful for order {OrderId}", order.Id);

                return HandlePaymentResult(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid payment method");
                return BadRequest(ex.Message);
            }
            catch (BadRequestException ex)
            {
                _logger.LogWarning(ex, "Payment validation failed");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Payment processing failed");

                if (order != null)
                {
                    await _orderFacade.CancelOrderAsync(order.Id);
                    _logger.LogInformation("Order {OrderId} cancelled due to payment failure", order.Id);
                }

                return StatusCode(500, "Payment processing failed");
            }
        }

        private IPaymentModel CreatePaymentModel(PaymentRequestDto request)
        {
            ArgumentNullException.ThrowIfNull(request.Model);
            return request.Method.ToLower() switch
            {
                PaymentMethod.Bank => new BankPaymentModel(_paymentSettings.BankInvoiceValidityDays),
                PaymentMethod.IBox => new BoxPaymentModel(),
                PaymentMethod.Visa => new VisaPaymentModel
                {
                    HolderName = request.Model.Holder,
                    CardNumber = request.Model.CardNumber,
                    ExpiryMonth = request.Model.MonthExpire,
                    ExpiryYear = request.Model.YearExpire,
                    CVV = request.Model.Cvv2.ToString("000")
                },
                _ => throw new ArgumentException("Invalid payment method")
            };
        }

        private static IActionResult HandlePaymentResult(PaymentResult result)
        {
            return result switch
            {
                BankPaymentResult bankResult => new FileContentResult(bankResult.PdfContent, "application/pdf")
                {
                    FileDownloadName = bankResult.FileName
                },

                BoxPaymentResult iboxResult => Ok(new BoxPaymentResultDto
                {
                    UserId = iboxResult.UserId,
                    OrderId = iboxResult.OrderId,
                    PaymentDate = iboxResult.PaymentDate,
                    Sum = iboxResult.Sum
                }),

                VisaPaymentResult => Ok(),

                _ => BadRequest("Unknown payment result type")
            };
        }
        private static BadRequestObjectResult BadRequest(string message) =>
            new BadRequestObjectResult(message);

        private static OkResult Ok() => new OkResult();

        private static OkObjectResult Ok<T>(T value) => new OkObjectResult(value);

        private static ObjectResult StatusCode(int code, string message) =>
            new ObjectResult(message) { StatusCode = code };
    }
}
