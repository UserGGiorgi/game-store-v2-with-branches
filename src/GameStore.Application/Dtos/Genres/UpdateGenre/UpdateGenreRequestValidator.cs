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
                .Must(BeAValidGuidIfPresent).WithMessage("Parent genre ID must be a valid GUID or null.")
                .When(x => x.ParentGenreId.HasValue)
                .Must((dto, parentId) => parentId != dto.Id).WithMessage("Genre cannot be its own parent.")
                .When(x => x.ParentGenreId.HasValue);
        }

        private bool BeAValidGuidIfPresent(Guid? guid)
        {
            return !guid.HasValue || guid.Value != Guid.Empty;
        }
    }
}