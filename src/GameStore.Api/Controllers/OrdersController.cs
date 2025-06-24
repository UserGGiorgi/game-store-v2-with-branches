using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces;
using GameStore.Application.Services;
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
        private readonly IPaymentService _paymentService;
        private readonly IPdfService _pdfService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            IOrderService orderService,
            ICartService cartService,
            IPaymentService paymentService,
            IPdfService pdfService,
            ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _cartService = cartService;
            _paymentService = paymentService;
            _pdfService = pdfService;
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
            _logger.LogInformation("Processing payment for user {UserId} with method {Method}", userId, request.Method);
            var order = await _orderService.GetOpenOrderAsync();
            if (order == null || !order.OrderGames.Any())
                return BadRequest("Cart is empty");

            return request.Method.ToLower() switch
            {
                "bank" => await ProcessBankPayment(userId, order),
                "ibox terminal" => await ProcessIBoxPayment(userId, order),
                "visa" => await ProcessVisaPayment(request.Model, userId, order),
                _ => BadRequest($"Unsupported payment method: {request.Method}")
            };
        }

        private async Task<IActionResult> ProcessBankPayment(Guid userId, Order order)
        {
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);
            var pdfBytes = _pdfService.GenerateBankInvoice(userId, order.Id, total);

            await _orderService.CloseOrderAsync(order.Id);

            return File(pdfBytes, "application/pdf", $"invoice_{order.Id}.pdf");
        }

        private async Task<IActionResult> ProcessIBoxPayment(Guid userId, Order order)
        {
            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);

            var iboxRequest = new IBoxPaymentRequest
            {
                UserId = userId,
                OrderId = order.Id,
                Amount = total
            };

            var result = await _paymentService.ProcessIBoxPaymentAsync(iboxRequest);

            // Close the current order
            await _orderService.CloseOrderAsync(order.Id);

            return Ok(new IBoxPaymentResultDto
            {
                UserId = result.UserId,
                OrderId = result.OrderId,
                PaymentDate = result.PaymentDate,
                Sum = result.Sum
            });
        }

        private async Task<IActionResult> ProcessVisaPayment(VisaPaymentModelDto model, Guid userId, Order order)
        {
            if (model == null)
                return BadRequest("Missing card details for Visa payment");

            var total = (decimal)order.OrderGames.Sum(item => item.Price * item.Quantity);

            var visaRequest = new VisaPaymentRequest
            {
                HolderName = model.Holder,
                CardNumber = model.CardNumber,
                ExpiryMonth = model.MonthExpire,
                ExpiryYear = model.YearExpire,
                CVV = model.Cvv2.ToString("000"),
                Amount = total
            };

            await _paymentService.ProcessVisaPaymentAsync(visaRequest);

            await _orderService.CloseOrderAsync(order.Id);

            return Ok();
        }

        private Guid GetStubUserId()
        {
            return Guid.Parse("a5e6c2d4-1b3f-4a7e-8c9d-0f1e2d3c4b5a");
        }
    }
}

