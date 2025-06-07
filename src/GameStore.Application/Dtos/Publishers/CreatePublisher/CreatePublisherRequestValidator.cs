using FluentValidation;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Publishers.CreatePublisher
{
    public class CreatePublisherRequestValidator : AbstractValidator<CreatePublisherDto>
    {
        public CreatePublisherRequestValidator()
        {
            RuleFor(x => x.publisher)
                .NotNull().WithMessage("Publisher information is required.")
                .SetValidator(new PublisherDtoValidator());
        }
    }
    public class PublisherDtoValidator : AbstractValidator<PublisherDto>
    {
        public PublisherDtoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");

            RuleFor(x => x.HomePage)
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.HomePage))
                .WithMessage("Home page URL cannot exceed 200 characters.")
                .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.HomePage))
                .WithMessage("Home page must be a valid URL.");

            RuleFor(x => x.Description)
                .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description cannot exceed 500 characters.");
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
