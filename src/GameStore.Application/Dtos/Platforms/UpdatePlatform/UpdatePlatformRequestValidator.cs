using FluentValidation;
using GameStore.Domain.Constraints.Games;

namespace GameStore.Application.Dtos.Platforms.UpdatePlatform
{
    public class UpdatePlatformRequestValidator : AbstractValidator<UpdatePlatformRequestDto>
    {
        public UpdatePlatformRequestValidator()
        {
            RuleFor(x => x.Platform)
                .NotNull()
                .SetValidator(new PlatformUpdateDtoValidator());
        }
    }

    public class PlatformUpdateDtoValidator : AbstractValidator<PlatformUpdateDto>
    {
        public PlatformUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(PlatformValidationConstraints.Messages.PlatformIdRequired);

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage(PlatformValidationConstraints.Messages.TypeRequired)
                .MaximumLength(PlatformValidationConstraints.Limits.Type)
                .WithMessage(PlatformValidationConstraints.Messages.TypeLength)
                .Matches(PlatformValidationConstraints.Patterns.Type)
                .WithMessage(PlatformValidationConstraints.Messages.TypeFormat);
        }
    }
}