using GameStore.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<IBoxPaymentResultDto> ProcessIBoxPaymentAsync(IBoxPaymentRequest request);
        Task ProcessVisaPaymentAsync(VisaPaymentRequest request);
    }
}
