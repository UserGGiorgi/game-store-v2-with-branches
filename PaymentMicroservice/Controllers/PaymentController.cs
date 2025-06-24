using Microsoft.AspNetCore.Mvc;

namespace PaymentMicroservice.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly Random _random = new();
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpPost("ibox")]
        public IActionResult ProcessIBox([FromBody] IBoxPaymentRequest request)
        {
            if (_random.NextDouble() < 0.1)
            {
                _logger.LogWarning("IBox payment failed randomly");
                return StatusCode(500, "Random payment failure");
            }

            return Ok(new IBoxPaymentResponse(
                UserId: request.UserId,
                OrderId: request.OrderId,
                PaymentDate: DateTime.UtcNow,
                Sum: request.Amount
            ));
        }

        [HttpPost("visa")]
        public IActionResult ProcessVisa([FromBody] VisaPaymentRequest request)
        {
            if (request.CardNumber.Length != 15 ||
                request.CVV.Length != 3 ||
                request.ExpiryYear < DateTime.Now.Year)
            {
                return BadRequest("Invalid card details");
            }

            // 10% failure simulation
            if (_random.NextDouble() < 0.1)
            {
                _logger.LogWarning("Visa payment failed randomly");
                return StatusCode(500, "Random payment failure");
            }

            return Ok();
        }
    }

    public record IBoxPaymentRequest(Guid UserId, Guid OrderId, decimal Amount);
    public record IBoxPaymentResponse(Guid UserId, Guid OrderId, DateTime PaymentDate, decimal Sum);
    public record VisaPaymentRequest(
        string CardNumber,
        string HolderName,
        int ExpiryMonth,
        int ExpiryYear,
        string CVV,
        decimal Amount);
}
