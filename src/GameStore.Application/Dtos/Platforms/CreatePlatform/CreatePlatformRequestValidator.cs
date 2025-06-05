using FluentValidation;
using GameStore.Application.Dtos.Platforms.GetPlatform;
using System.Text.RegularExpressions;

namespace GameStore.Application.Dtos.Platforms.CreatePlatform
{
    public class CreatePlatformRequestValidator : AbstractValidator<CreatePlatformRequestDto>
    {
        public CreatePlatformRequestValidator(IValidator<PlatformDto> platformValidator)
        {
            RuleFor(x => x.Platform)
                .NotNull()
                .SetValidator(platformValidator); // Use injected validator
        }
    }

    public class PlatformDtoValidator : AbstractValidator<PlatformDto>
    {
        public PlatformDtoValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Platform type is required.")
                .MaximumLength(50).WithMessage("Platform type cannot exceed 50 characters.")
                .Matches(@"^[a-zA-Z][a-zA-Z0-9 ]*$") // Must start with letter
                .WithMessage("Platform type must start with a letter and can only contain alphanumeric characters and spaces.");
        }
    }
}