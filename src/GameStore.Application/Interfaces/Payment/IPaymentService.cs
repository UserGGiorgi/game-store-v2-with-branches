using GameStore.Domain.Entities.Orders;

namespace GameStore.Application.Interfaces.Payment
{
    public interface IPaymentService
    {
        Task<PaymentResult> PayAsync(Order order, Guid userId, IPaymentModel model);
    }
    public interface IPaymentModel { }

    public abstract class PaymentResult { }
}
