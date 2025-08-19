using GameStore.Application.Interfaces.Payment;

namespace GameStore.Application.Dtos.Order.PaymentModels
{
    public class BankPaymentModel : IPaymentModel
    {
        public DateTime IssueDate { get; } = DateTime.UtcNow;
        public DateTime ExpiryDate { get; }

        public BankPaymentModel(DateTime expiryDate)
        {
            ExpiryDate = expiryDate;
        }
        public BankPaymentModel(int validityDays) : this(DateTime.UtcNow.AddDays(validityDays))
        {
        }
    }
}
