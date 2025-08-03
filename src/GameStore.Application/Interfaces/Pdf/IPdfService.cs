using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Pdf
{
    public interface IPdfService
    {
        byte[] GenerateBankInvoice(Guid userId, Guid orderId, decimal total);
    }
}
