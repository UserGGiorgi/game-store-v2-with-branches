using FluentValidation;
using GameStore.Application.Dtos.Platforms.UpdatePlatform;

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
                .NotEmpty().WithMessage("Platform ID is required.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Platform type is required.")
                .MaximumLength(50).WithMessage("Platform type cannot exceed 50 characters.")
                .Matches(@"^[a-zA-Z][a-zA-Z0-9 ]*$")
                .WithMessage("Platform type must start with a letter and can only contain alphanumeric characters and spaces.");
        }
    }
}