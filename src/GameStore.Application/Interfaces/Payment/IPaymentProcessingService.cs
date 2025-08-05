using GameStore.Application.Dtos.Order.PaymentRequest;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Application.Interfaces.Payment
{
    public interface IPaymentProcessingService
    {
        Task<IActionResult> ProcessPaymentAsync(Guid userId, PaymentRequestDto request);
    }
}
