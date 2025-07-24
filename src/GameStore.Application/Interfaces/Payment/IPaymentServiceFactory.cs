using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Payment
{
    public interface IPaymentServiceFactory
    {
        IPaymentService Create(string paymentMethod);
    }
}
