using FluentValidation;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Domain.Constraints;

namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class BankPaymentModelValidator : AbstractValidator<BankPaymentModel>
    {
        public BankPaymentModelValidator()
        {
            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage(BankPaymentConstraints.Messages.ExpiryDateRequired);
        }
    }
}
