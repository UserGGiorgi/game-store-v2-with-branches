using FluentValidation;
using GameStore.Domain.Constraints;
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
                .GreaterThanOrEqualTo(0)
                .WithMessage(BoxPaymentConstraints.Messages.TransactionAmountPositive);

            RuleFor(x => x.accountNumber)
                .NotEmpty()
                .WithMessage(BoxPaymentConstraints.Messages.AccountNumberRequired)
                .NotEqual(Guid.Empty)
                .WithMessage(BoxPaymentConstraints.Messages.AccountNumberNotEmpty);

            RuleFor(x => x.invoiceNumber)
                .NotEmpty()
                .WithMessage(BoxPaymentConstraints.Messages.InvoiceNumberRequired)
                .NotEqual(Guid.Empty)
                .WithMessage(BoxPaymentConstraints.Messages.InvoiceNumberNotEmpty);
        }
    }
}
