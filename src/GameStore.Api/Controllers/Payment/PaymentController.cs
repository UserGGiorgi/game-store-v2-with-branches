using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Interfaces.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStore.Api.Controllers.Payment
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentProcessingService _paymentProcessingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentProcessingService paymentProcessingService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<PaymentController> logger)
        {
            _paymentProcessingService = paymentProcessingService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpPost("/orders/payment")]
        [Authorize(Policy = "BuyGames")]
        public async Task<IActionResult> ProcessPayment(
            [FromBody] PaymentRequestDto request)
        {
            var userId = GetCurrentUserId();
            return await _paymentProcessingService.ProcessPaymentAsync(userId, request);
        }
        private Guid GetCurrentUserId()
        {
            var userIdClaim =
                _httpContextAccessor.HttpContext?.User?.FindFirst("userid") ??
                _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier) ??
                _httpContextAccessor.HttpContext?.User?.FindFirst("sub");

            if (userIdClaim == null)
            {
                var claims = _httpContextAccessor.HttpContext?.User?.Claims
                    .Select(c => $"{c.Type}: {c.Value}");
                _logger.LogError("Missing user ID claim. Available claims: {@Claims}", claims);
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var userIdString = userIdClaim.Value;
            if (userIdString.Length == 35 && userIdString.EndsWith("00000"))
            {
                userIdString = string.Concat(userIdString.AsSpan(0, 35), "0");
            }

            if (!Guid.TryParse(userIdString, out var userId))
            {
                _logger.LogError("Invalid user ID format: {UserIdString}", userIdString);
                throw new UnauthorizedAccessException("Invalid user identity format");
            }

            return userId;
        }
    }
}
