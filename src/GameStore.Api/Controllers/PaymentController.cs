using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Facade;
using GameStore.Application.Interfaces.Payment;
using GameStore.Domain.Constraints;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentProcessingService _paymentProcessingService;

        public PaymentController(IPaymentProcessingService paymentProcessingService)
        {
            _paymentProcessingService = paymentProcessingService;
        }

        [HttpPost("/orders/payment")]
        //[Authorize(Policy = "BuyGames")]
        public async Task<IActionResult> ProcessPayment(
            [FromBody] PaymentRequestDto request)
        {
            var userId = GetStubUserId();
            if (userId == Guid.Empty)
                return Unauthorized("Invalid user credentials");

            return await _paymentProcessingService.ProcessPaymentAsync(userId, request);
        }
        private static Guid GetStubUserId()
        {
            return Guid.Parse("a5e6c2d4-1b3f-4a7e-8c9d-0f1e2d3c4b5a");
        }
    }
}
