namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class VisaPaymentRequest
    {
        public string CardHolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
