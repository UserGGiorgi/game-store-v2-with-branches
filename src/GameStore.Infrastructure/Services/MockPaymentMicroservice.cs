using GameStore.Application.Dtos.Order;
using GameStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    public class MockPaymentMicroservice : IPaymentMicroservice
    {
        public async Task<IBoxPaymentResultDto> ProcessIBoxPaymentAsync(IBoxPaymentRequest request)
        {
            return new IBoxPaymentResultDto
            {
                UserId = Guid.Empty,
                OrderId = request.OrderId,
                PaymentDate = DateTime.UtcNow,
                Sum = (double)request.Amount
            };
        }
        public async Task ProcessVisaPaymentAsync(VisaPaymentRequest request)
        {
            // Simulate Visa payment processing
            await Task.Delay(100); // Fake async call
            if (request.CVV == 0) throw new Exception("Invalid CVV");
        }
    }
}
