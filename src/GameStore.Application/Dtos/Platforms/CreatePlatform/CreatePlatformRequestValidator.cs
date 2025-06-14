using FluentValidation;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using GameStore.Domain.Constraints;
using System.Text.RegularExpressions;

namespace GameStore.Application.Dtos.Platforms.CreatePlatform
{
    public class CreatePlatformRequestValidator : AbstractValidator<CreatePlatformRequestDto>
    {
        public CreatePlatformRequestValidator(IValidator<PlatformDto> platformValidator)
        {
            RuleFor(x => x.Platform)
                .NotNull()
                .SetValidator(platformValidator);
        }
    }

    public class PlatformDtoValidator : AbstractValidator<PlatformDto>
    {
        public PlatformDtoValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage(PlatformValidationConstraints.Messages.TypeRequired)
                .MaximumLength(PlatformValidationConstraints.Limits.Type)
                .WithMessage(PlatformValidationConstraints.Messages.TypeLength)
                .Matches(PlatformValidationConstraints.Patterns.Type)
                .WithMessage(PlatformValidationConstraints.Messages.TypeFormat);
        }
    }
}