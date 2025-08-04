using GameStore.Application.Dtos.Order;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model);
    }
    public interface IPaymentModel { }

    public abstract class PaymentResult { }
}
