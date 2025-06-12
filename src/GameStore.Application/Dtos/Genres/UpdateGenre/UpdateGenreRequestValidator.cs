using FluentValidation;
using GameStore.Application.Dtos.Genres.UpdateGenre;

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
                .NotEmpty().WithMessage("Genre ID is required.");

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