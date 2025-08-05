using FluentValidation;
using GameStore.Domain.Constraints.Payment;

namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class VisaPaymentRequestValidator : AbstractValidator<VisaPaymentRequest>
    {
        public VisaPaymentRequestValidator()
        {
            RuleFor(x => x.CardHolderName)
                .NotEmpty().WithMessage(PaymentValidationConstraints.Messages.HolderNameRequired)
                .Matches(PaymentValidationConstraints.Patterns.HolderName)
                .WithMessage(PaymentValidationConstraints.Messages.HolderNameFormat);

            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage(PaymentValidationConstraints.Messages.CardNumberRequired)
                .Length(PaymentValidationConstraints.Limits.CardNumberLength)
                .WithMessage(PaymentValidationConstraints.Messages.CardNumberLength)
                .Matches(PaymentValidationConstraints.Patterns.CardNumber)
                .WithMessage(PaymentValidationConstraints.Messages.CardNumberFormat);

            RuleFor(x => x.ExpirationMonth)
                .InclusiveBetween(PaymentValidationConstraints.Limits.MonthMin,
                                PaymentValidationConstraints.Limits.MonthMax)
                .WithMessage(PaymentValidationConstraints.Messages.MonthExpireRange);

            RuleFor(x => x.ExpirationYear)
                .Must(BeValidExpirationYear)
                .WithMessage(PaymentValidationConstraints.Messages.YearExpireInvalid);

            RuleFor(x => x.Cvv)
                .InclusiveBetween(PaymentValidationConstraints.Limits.CvvMin,
                                PaymentValidationConstraints.Limits.CvvMax)
                .WithMessage(PaymentValidationConstraints.Messages.Cvv2Range);

            RuleFor(x => x.TransactionAmount)
                .GreaterThanOrEqualTo(0).WithMessage(PaymentValidationConstraints.Messages.TransactionGreaterThanEqualZero);
        }

        private bool BeValidExpirationYear(int year)
        {
            return year >= DateTime.Now.Year;
        }
    }
}
