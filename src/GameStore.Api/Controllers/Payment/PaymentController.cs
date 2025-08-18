using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Interfaces.Auth;
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
        private readonly IUserContextService _userContext;

        public PaymentController(IPaymentProcessingService paymentProcessingService,
            IUserContextService userContextService)
        {
            _paymentProcessingService = paymentProcessingService;
            _userContext = userContextService;
        }

        [HttpPost("/orders/payment")]
        [Authorize(Policy = "BuyGames")]
        public async Task<IActionResult> ProcessPayment(
            [FromBody] PaymentRequestDto request)
        {
            var userId = _userContext.GetCurrentUserId();
            return await _paymentProcessingService.ProcessPaymentAsync(userId, request);
        }
    }
}
