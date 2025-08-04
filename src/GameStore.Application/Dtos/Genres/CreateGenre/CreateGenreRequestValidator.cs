using FluentValidation;
using GameStore.Application.Dtos.Genres.GetGenre;
using GameStore.Domain.Constraints;
using System;

namespace GameStore.Application.Dtos.Genres.CreateGenre
{
    public class CreateGenreRequestValidator : AbstractValidator<CreateGenreRequestDto>
    {
        public CreateGenreRequestValidator()
        {
            RuleFor(x => x.Genre)
                .NotNull()
                .SetValidator(new GenreDtoValidator());
        }
    }

    public class GenreDtoValidator : AbstractValidator<GenreDto>
    {
        public GenreDtoValidator()
        {
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