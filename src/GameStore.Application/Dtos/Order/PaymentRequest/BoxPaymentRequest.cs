namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class BoxPaymentRequest
    {
        public decimal transactionAmount { get; set; }
        public Guid accountNumber { get; set; }
        public Guid invoiceNumber { get; set; }
    }
}
