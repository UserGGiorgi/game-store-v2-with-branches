using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class BoxPaymentRequestValidator : AbstractValidator<BoxPaymentRequest>
    {
        public BoxPaymentRequestValidator()
        {
            RuleFor(x => x.transactionAmount)
                .GreaterThanOrEqualTo(0) // Allows 0 or positive values
                .WithMessage("Transaction amount must be 0 or positive");

            RuleFor(x => x.accountNumber)
                .NotEmpty()
                .WithMessage("Account number is required")
                .NotEqual(Guid.Empty)
                .WithMessage("Account number cannot be empty");

            RuleFor(x => x.invoiceNumber)
                .NotEmpty()
                .WithMessage("Invoice number is required")
                .NotEqual(Guid.Empty)
                .WithMessage("Invoice number cannot be empty");
        }
    }
}
