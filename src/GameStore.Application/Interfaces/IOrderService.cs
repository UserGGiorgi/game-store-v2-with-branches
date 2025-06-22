using GameStore.Application.Dtos.Order;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IOrderService
    {
        Task<FileContentResult> ProcessBankPayment(Guid orderId);
        Task<IEnumerable<OrderResponseDto>> GetPaidAndCancelledOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync(Guid orderId);
        Task<IEnumerable<OrderDetailDto>> GetCartAsync();
        Task<IEnumerable<PaymentMethodDto>> GetPaymentMethodsAsync();
        //Task ProcessVisaPayment(Guid orderId, VisaPaymentModelDto model);

    }
}
