using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Payment
{
    public static class BoxPaymentConstraints
    {
        public static class Messages
        {
            public const string TransactionAmountPositive = "Transaction amount must be 0 or positive";
            public const string AccountNumberRequired = "Account number is required";
            public const string AccountNumberNotEmpty = "Account number cannot be empty";
            public const string InvoiceNumberRequired = "Invoice number is required";
            public const string InvoiceNumberNotEmpty = "Invoice number cannot be empty";
        }
    }
}
