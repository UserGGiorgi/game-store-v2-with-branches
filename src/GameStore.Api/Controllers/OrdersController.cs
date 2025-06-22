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
        private readonly IConfiguration _config;

        public OrdersController(
            IOrderService orderService,
            ICartService cartService,
            IPaymentService paymentService,
            IPdfService pdfService,
            ILogger<OrdersController> logger,
            IConfiguration config)
        {
            _orderService = orderService;
            _cartService = cartService;
            _paymentService = paymentService;
            _pdfService = pdfService;
            _logger = logger;
            _config = config;
        }
        [HttpPost("/games/{key}/buy")]
        public async Task<IActionResult> AddToCart(string key)
        {
            try
            {
                await _cartService.AddToCartAsync(key);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("cart/{key}")]
        public async Task<IActionResult> RemoveFromCart(string key)
        {
            try
            {
                await _cartService.RemoveFromCartAsync(key);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
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
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetOrderDetails(Guid id)
        {
            try
            {
                var details = await _orderService.GetOrderDetailsAsync(id);
                return Ok(details);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
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
            var userId = GetCurrentUserId();
            if (userId == Guid.Empty)
                return Unauthorized("Invalid user credentials");

            // Get current cart
            var cartItems = await _orderService.GetCartAsync();
            if (cartItems == null || !cartItems.Any())
                return BadRequest("Cart is empty");

            // Create a temporary order ID for processing
            var tempOrderId = Guid.NewGuid();

            return request.Method.ToLower() switch
            {
                "bank" => await ProcessBankPayment(userId, tempOrderId, cartItems),
                "ibox terminal" => await ProcessIBoxPayment(userId, tempOrderId, cartItems),
                "visa" => await ProcessVisaPayment(request.Model, userId, tempOrderId, cartItems),
                _ => BadRequest($"Unsupported payment method: {request.Method}")
            };
        }

        private async Task<IActionResult> ProcessBankPayment(Guid userId, Guid tempOrderId, IEnumerable<OrderDetailDto> cartItems)
        {
            // Calculate total from cart items
            var total = (decimal)cartItems.Sum(item => item.Price * item.Quantity);

            // Create the PDF
            var pdfBytes = _pdfService.GenerateBankInvoice(userId, tempOrderId, total);

            // Return the file
            return File(pdfBytes, "application/pdf", $"invoice_{tempOrderId}.pdf");
        }

        private async Task<IActionResult> ProcessIBoxPayment(Guid userId, Guid tempOrderId, IEnumerable<OrderDetailDto> cartItems)
        {
            // Calculate total from cart items
            var total = (decimal)cartItems.Sum(item => item.Price * item.Quantity);

            var iboxRequest = new IBoxPaymentRequest
            {
                UserId = userId,
                OrderId = tempOrderId,
                Amount = total
            };

            var result = await _paymentService.ProcessIBoxPaymentAsync(iboxRequest);

            return Ok(new IBoxPaymentResultDto
            {
                UserId = result.UserId,
                OrderId = result.OrderId,
                PaymentDate = result.PaymentDate,
                Sum = result.Sum
            });
        }

        private async Task<IActionResult> ProcessVisaPayment(VisaPaymentModelDto model, Guid userId, Guid tempOrderId, IEnumerable<OrderDetailDto> cartItems)
        {
            if (model == null)
                return BadRequest("Missing card details for Visa payment");

            // Calculate total from cart items
            var total = (decimal)cartItems.Sum(item => item.Price * item.Quantity);

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
            return Ok(); // 200 OK
        }

        private Guid GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }
            return Guid.Empty;
        }
    }
}

