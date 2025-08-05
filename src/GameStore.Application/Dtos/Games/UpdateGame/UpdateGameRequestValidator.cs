using FluentValidation;
using GameStore.Domain.Constraints.Games;

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
                .NotEmpty().WithMessage(GameValidationConstraints.Messages.GenresRequired)
                .ForEach(id => id.NotEmpty()
                    .WithMessage(string.Format(
                        GameValidationConstraints.Messages.IdNotEmpty,
                        "Genre")));

            RuleFor(x => x.Platforms)
                .NotEmpty().WithMessage(GameValidationConstraints.Messages.PlatformsRequired)
                .ForEach(id => id.NotEmpty()
                    .WithMessage(string.Format(
                        GameValidationConstraints.Messages.IdNotEmpty,
                        "Platform")));

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage(GameValidationConstraints.Messages.Required);
        }
    }

    public class GameUpdateDtoValidator : AbstractValidator<GameUpdateDto>
    {
        public GameUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(GameValidationConstraints.Messages.Required);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(GameValidationConstraints.Messages.Required)
                .MaximumLength(GameValidationConstraints.Limits.Name)
                .WithMessage(GameValidationConstraints.Messages.NameLength);

            RuleFor(x => x.Key)
                .NotEmpty().WithMessage(GameValidationConstraints.Messages.Required)
                .Matches(GameValidationConstraints.Patterns.Key)
                .WithMessage(GameValidationConstraints.Messages.KeyFormat)
                .MaximumLength(GameValidationConstraints.Limits.Key)
                .WithMessage(GameValidationConstraints.Messages.KeyLength);

            RuleFor(x => x.Description)
                .MaximumLength(GameValidationConstraints.Limits.Description)
                .WithMessage(GameValidationConstraints.Messages.DescriptionLength)
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(GameValidationConstraints.Limits.MinPrice)
                .WithMessage(GameValidationConstraints.Messages.PriceMin);

            RuleFor(x => x.UnitInStock)
                .GreaterThanOrEqualTo(GameValidationConstraints.Limits.MinStock)
                .WithMessage(GameValidationConstraints.Messages.StockMin);

            RuleFor(x => x.Discount)
                .InclusiveBetween(
                    GameValidationConstraints.Limits.MinDiscount,
                    GameValidationConstraints.Limits.MaxDiscount)
                .WithMessage(GameValidationConstraints.Messages.DiscountRange);
        }
    }
}