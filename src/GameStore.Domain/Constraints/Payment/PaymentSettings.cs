using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Payment
{
    public class PaymentSettings
    {
        public int BankInvoiceValidityDays { get; set; } = 30;
    }
}
