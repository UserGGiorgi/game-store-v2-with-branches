using FluentValidation;
using GameStore.Application.Dtos.Order.PaymentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Order.PaymentRequest
{
    public class BankPaymentModelValidator : AbstractValidator<BankPaymentModel>
    {
        public BankPaymentModelValidator()
        {
            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Invoice must have a future expiry date");
        }
    }
}
