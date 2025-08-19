using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Payment
{
    public static class PaymentValidationConstraints
    {
        public static class Limits
        {
            public const int CardNumberLength = 16;
            public const int CvvMin = 1;
            public const int CvvMax = 999;
            public const int MonthMin = 1;
            public const int MonthMax = 12;
        }

        public static class Patterns
        {
            public const string CardNumber = "^[0-9]+$";
            public const string HolderName = "^[a-zA-Z ]+$";
        }

        public static class Messages
        {
            public const string MethodRequired = "Payment method is required.";
            public const string ModelRequired = "Payment model is required for this method.";
            public const string TransactionGreaterThanEqualZero = "Transaction amount must be greater Or equal than 0";

            public const string HolderNameRequired = "Card holder name is required.";
            public const string HolderNameFormat = "Card holder name can only contain letters and spaces.";

            public const string CardNumberRequired = "Card number is required.";
            public static readonly string CardNumberLength = $"Card number must be {Limits.CardNumberLength} digits.";
            public const string CardNumberFormat = "Card number can only contain digits.";

            public static readonly string MonthExpireRange = $"Expiration month must be between {Limits.MonthMin} and {Limits.MonthMax}.";

            public const string YearExpireInvalid = "Expiration year cannot be in the past.";

            public static readonly string Cvv2Range = $"CVV must be between {Limits.CvvMin} and {Limits.CvvMax}.";
        }
    }
}
