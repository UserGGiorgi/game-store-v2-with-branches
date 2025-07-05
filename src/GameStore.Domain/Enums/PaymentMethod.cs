using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Enums
{
    public class PaymentMethod
    {
        public const string None = "";
        public const string Visa = "visa";
        public const string Bank = "bank";
        public const string IBox = "ibox terminal";
    }
}
