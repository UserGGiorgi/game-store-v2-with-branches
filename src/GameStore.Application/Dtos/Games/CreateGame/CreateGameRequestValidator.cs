using FluentValidation;
using GameStore.Application.Dtos.Games.CreateGames;
using GameStore.Application.Dtos.Games.GetGames;

namespace GameStore.Dtos.Games
{
    public class CreateGameRequestValidator : AbstractValidator<CreateGameRequestDto>
    {
        public CreateGameRequestValidator()
        {
            RuleFor(x => x.Game).NotNull().SetValidator(new GameDtoValidator());

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

    public class GameDtoValidator : AbstractValidator<GameDto>
    {
        public GameDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Key is required.")
                .Matches("^[a-z0-9-]+$").WithMessage("Key must be lowercase alphanumeric with hyphens.");

            RuleFor(x => x.Description)
                .MaximumLength(500).When(x => x.Description != null)
                .WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative.");

            RuleFor(x => x.UnitInStock)
                .GreaterThanOrEqualTo(0).WithMessage("Unit in stock cannot be negative.");

            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100 percent.");
        }
    }
}