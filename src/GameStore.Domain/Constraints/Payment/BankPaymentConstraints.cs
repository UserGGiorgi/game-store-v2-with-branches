using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Payment
{
    public static class BankPaymentConstraints
    {
        public static class Messages
        {
            public const string ExpiryDateRequired = "Invoice must have a future expiry date";
        }
    }
}
