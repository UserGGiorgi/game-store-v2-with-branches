using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentResults
{
    public class BoxApiResponse
    {
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("invoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonPropertyName("paymentMethod")]
        public int PaymentMethod { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
