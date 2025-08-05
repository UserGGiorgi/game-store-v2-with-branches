using FluentValidation;
using GameStore.Domain.Constraints.Games;

namespace GameStore.Application.Dtos.Genres.UpdateGenre
{
    public class UpdateGenreRequestValidator : AbstractValidator<UpdateGenreRequestDto>
    {
        public UpdateGenreRequestValidator()
        {
            RuleFor(x => x.Genre)
                .NotNull()
                .SetValidator(new GenreUpdateDtoValidator());
        }
    }

    public class GenreUpdateDtoValidator : AbstractValidator<GenreUpdateDto>
    {
        public GenreUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(GenreValidationConstraints.Messages.GenreIdRequired);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(GenreValidationConstraints.Messages.NameRequired)
                .MaximumLength(GenreValidationConstraints.Limits.Name)
                .WithMessage(GenreValidationConstraints.Messages.NameLength)
                .Matches(GenreValidationConstraints.Patterns.Name)
                .WithMessage(GenreValidationConstraints.Messages.NameFormat);

            RuleFor(x => x.ParentGenreId)
                .Must(BeValidGuidOrNullOrEmpty)
                .WithMessage(GenreValidationConstraints.Messages.ParentIdFormat);
        }

        private bool BeValidGuidOrNullOrEmpty(string? parentGenreId)
        {
            if (string.IsNullOrEmpty(parentGenreId))
                return true;

            return Guid.TryParse(parentGenreId, out _);
        }
    }
}