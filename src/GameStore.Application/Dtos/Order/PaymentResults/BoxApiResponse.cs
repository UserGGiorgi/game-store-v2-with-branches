using System.Text.Json.Serialization;

namespace GameStore.Application.Dtos.Order.PaymentResults
{
    public class BoxApiResponse
    {
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonPropertyName("invoiceNumber")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [JsonPropertyName("paymentMethod")]
        public int PaymentMethod { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
