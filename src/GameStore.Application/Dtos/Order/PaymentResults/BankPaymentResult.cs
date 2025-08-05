using GameStore.Application.Interfaces.Payment;

namespace GameStore.Application.Dtos.Order.PaymentResults
{
    public class BankPaymentResult : PaymentResult
    {
        public byte[] PdfContent { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }
}
