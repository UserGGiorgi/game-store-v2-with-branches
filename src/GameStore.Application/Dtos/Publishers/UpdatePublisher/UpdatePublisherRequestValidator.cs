using FluentValidation;
using GameStore.Domain.Constraints;

namespace GameStore.Application.Dtos.Publishers.UpdatePublisher
{
    public class UpdatePublisherRequestValidator : AbstractValidator<UpdatePublisherRequestDto>
    {
        public UpdatePublisherRequestValidator()
        {
            RuleFor(x => x.Publisher)
                .NotNull().WithMessage(PublisherValidationConstraints.Messages.PublisherRequired)
                .SetValidator(new UpdatePublisherDtoValidator());
        }
    }

    public class UpdatePublisherDtoValidator : AbstractValidator<UpdatePublisherDto>
    {
        public UpdatePublisherDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(PublisherValidationConstraints.Messages.PublisherIdRequired);

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
            if (string.IsNullOrWhiteSpace(url))
                return true;

            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
