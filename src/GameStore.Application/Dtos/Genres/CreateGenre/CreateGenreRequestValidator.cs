using System;
using FluentValidation;
using GameStore.Application.Dtos.Genres.GetGenre;

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
                .NotEmpty().WithMessage("Genre name is required.")
                .MaximumLength(50).WithMessage("Genre name cannot exceed 50 characters.")
                .Matches("^[a-zA-Z0-9 ]+$").WithMessage("Genre name can only contain alphanumeric characters and spaces.");

            RuleFor(x => x.ParentGenreId)
            .Must(BeValidGuidOrNullOrEmpty)
            .WithMessage("ParentGenreId must be a valid GUID or empty");
        }

        private bool BeValidGuidOrNullOrEmpty(string? parentGenreId)
        {
            if (string.IsNullOrEmpty(parentGenreId))
                return true;

            return Guid.TryParse(parentGenreId, out _);
        }
    }
}