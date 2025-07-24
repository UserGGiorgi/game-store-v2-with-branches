using GameStore.Application.Interfaces.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentResults
{
    public class BoxPaymentResult : PaymentResult
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Sum { get; set; }
    }
}
