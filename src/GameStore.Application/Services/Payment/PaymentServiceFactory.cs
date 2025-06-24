using GameStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Payment
{
    public class PaymentServiceFactory : IPaymentServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentService Create(string paymentMethod)
        {
            return paymentMethod.ToLower() switch
            {
                "bank" => _serviceProvider.GetRequiredService<BankPaymentService>(),
                "ibox terminal" => _serviceProvider.GetRequiredService<IBoxPaymentService>(),
                "visa" => _serviceProvider.GetRequiredService<VisaPaymentService>(),
                _ => throw new ArgumentException($"Unsupported payment method: {paymentMethod}")
            };
        }
    }
}
