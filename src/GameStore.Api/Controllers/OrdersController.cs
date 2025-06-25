using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using GameStore.Application.Services.Payment;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Security.Claims;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IPaymentServiceFactory _paymentServiceFactory;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            IOrderService orderService,
            ICartService cartService,
            IPaymentServiceFactory paymentServiceFactory,
            ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _cartService = cartService;
            _paymentServiceFactory = paymentServiceFactory;
            _logger = logger;
        }
        [HttpPost("/games/{key}/buy")]
        public async Task<IActionResult> AddToCart(string key)
        {
            await _cartService.AddToCartAsync(key);
            return Ok();
        }

        [HttpDelete("cart/{key}")]
        public async Task<IActionResult> RemoveFromCart(string key)
        {
            await _cartService.RemoveFromCartAsync(key);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetPaidAndCancelledOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetOrderDetails(Guid id)
        {
            var details = await _orderService.GetOrderDetailsAsync(id);
            return Ok(details);
        }
        [HttpGet("cart")]
        public async Task<IActionResult> GetCart()
        {
            var cartItems = await _orderService.GetCartAsync();
            return Ok(cartItems);
        }

        [HttpGet("payment-methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var methods = await _orderService.GetPaymentMethodsAsync();
            return Ok(new { paymentMethods = methods });
        }
        [HttpPost("payment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDto request)
        {
            var userId = GetStubUserId();
            if (userId == Guid.Empty)
                return Unauthorized("Invalid user credentials");

            _logger.LogInformation("Processing payment for user {UserId} with method {Method}",
                userId, request.Method);

            var order = await _orderService.GetOpenOrderAsync();
            if (order == null || order.OrderGames.Count == 0)
                return BadRequest("Cart is empty");

            if(request.Model == null)
            {
                return BadRequest("model is empty");
            }
            // Convert DTO to domain model
            IPaymentModel model = request.Method.ToLower() switch
            {
                "bank" => new BankPaymentModel(),
                "ibox terminal" => new BoxPaymentModel(),
                "visa" => new VisaPaymentModel
                {
                    HolderName = request.Model.Holder,
                    CardNumber = request.Model.CardNumber,
                    ExpiryMonth = request.Model.MonthExpire,
                    ExpiryYear = request.Model.YearExpire,
                    CVV = request.Model.Cvv2.ToString("000")
                },
                _ => throw new ArgumentException("Invalid payment method")
            };

            // Factory creates appropriate service
            var paymentService = _paymentServiceFactory.Create(request.Method);
            var result = await paymentService.PayAsync(order, userId, model);

            await _orderService.CloseOrderAsync(order.Id);

            // Handle different result types
            return result switch
            {
                BankPaymentResult bankResult =>
                    File(bankResult.PdfContent, "application/pdf", bankResult.FileName),

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

        private static Guid GetStubUserId()
        {
            return Guid.Parse("a5e6c2d4-1b3f-4a7e-8c9d-0f1e2d3c4b5a");
        }
    }
}

