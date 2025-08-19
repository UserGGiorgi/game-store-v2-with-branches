using GameStore.Application.Dtos.Order.PaymentModels;

namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class PaymentRequestDto
    {
        public string Method { get; set; } = string.Empty;

        public VisaPaymentModelDto? Model { get; set; }  = new ();
    }

}
