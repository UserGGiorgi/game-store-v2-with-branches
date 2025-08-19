namespace GameStore.Application.Interfaces.Payment
{
    public interface IPaymentServiceFactory
    {
        IPaymentService Create(string paymentMethod);
    }
}
