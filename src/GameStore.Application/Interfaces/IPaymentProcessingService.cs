using GameStore.Application.Dtos.Order.PaymentRequest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IPaymentProcessingService
    {
        Task<IActionResult> ProcessPaymentAsync(Guid userId, PaymentRequestDto request);
    }
}
