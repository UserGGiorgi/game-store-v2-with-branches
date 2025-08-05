using FluentValidation;
using GameStore.Application.Dtos.Publishers.GetPublisher;
using GameStore.Domain.Constraints;

namespace GameStore.Application.Dtos.Publishers.CreatePublisher
{
    public class CreatePublisherRequestValidator : AbstractValidator<CreatePublisherRequestDto>
    {
        public CreatePublisherRequestValidator()
        {
            RuleFor(x => x.Publisher)
                .NotNull().WithMessage(PublisherValidationConstraints.Messages.PublisherRequired)
                .SetValidator(new PublisherDtoValidator());
        }
    }
    public class PublisherDtoValidator : AbstractValidator<PublisherDto>
    {
        public PublisherDtoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage(PublisherValidationConstraints.Messages.CompanyNameRequired)
                .MaximumLength(PublisherValidationConstraints.Limits.CompanyName)
                .WithMessage(PublisherValidationConstraints.Messages.CompanyNameLength);

            RuleFor(x => x.HomePage)
                .MaximumLength(PublisherValidationConstraints.Limits.HomePage)
                .When(x => !string.IsNullOrEmpty(x.HomePage))
                .WithMessage(PublisherValidationConstraints.Messages.HomePageLength)
                .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.HomePage))
                .WithMessage(PublisherValidationConstraints.Messages.HomePageFormat);

            RuleFor(x => x.Description)
                .MaximumLength(PublisherValidationConstraints.Limits.Description)
                .When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage(PublisherValidationConstraints.Messages.DescriptionLength);
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
