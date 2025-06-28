using GameStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentModels
{
    public class BankPaymentModel : IPaymentModel
    {
        public DateTime IssueDate { get; } = DateTime.UtcNow;
        public DateTime ExpiryDate { get; }

        public BankPaymentModel(int validityDays)
        {
            ExpiryDate = IssueDate.AddDays(validityDays);
        }
    }
}
