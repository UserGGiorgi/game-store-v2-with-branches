using GameStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentModels
{
    public class VisaPaymentModel : IPaymentModel
    {
        public string HolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string CVV { get; set; } = string.Empty;
    }
}
