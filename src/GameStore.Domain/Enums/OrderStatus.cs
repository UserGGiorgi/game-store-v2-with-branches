using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Enums
{
    public enum OrderStatus
    {
        Open,
        Checkout,
        Paid,
        Cancelled,
        Shipped
    }

}
