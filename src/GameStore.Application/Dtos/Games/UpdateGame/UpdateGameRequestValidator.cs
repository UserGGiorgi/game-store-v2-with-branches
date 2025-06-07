using FluentValidation;
using GameStore.Application.Dtos.Games.UpdateGames;

namespace GameStore.Application.Dtos.Games.UpdateGames
{
    public class UpdateGameRequestValidator : AbstractValidator<UpdateGameRequestDto>
    {
        public UpdateGameRequestValidator()
        {
            RuleFor(x => x.Game)
                .NotNull()
                .SetValidator(new GameUpdateDtoValidator());

            RuleFor(x => x.Genres)
                .NotEmpty().WithMessage("At least one genre is required.")
                .ForEach(id => id.NotEmpty().WithMessage("Genre ID cannot be empty."));

            RuleFor(x => x.Platforms)
                .NotEmpty().WithMessage("At least one platform is required.")
                .ForEach(id => id.NotEmpty().WithMessage("Platform ID cannot be empty."));

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("Publisher is required.");
        }
    }

    public class GameUpdateDtoValidator : AbstractValidator<GameUpdateDto>
    {
        public GameUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Game ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Key is required.")
                .Matches("^[a-z0-9-]+$").WithMessage("Key must contain only lowercase letters, numbers, and hyphens.")
                .MaximumLength(50).WithMessage("Key cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");

            RuleFor(x => x.UnitInStock)
                .GreaterThanOrEqualTo(0).WithMessage("Unit in stock cannot be negative.");

            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100 percent.");
        }
    }
}