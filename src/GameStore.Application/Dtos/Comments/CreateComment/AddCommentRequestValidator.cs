using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Comments.CreateComment
{
    public class AddCommentRequestValidator : AbstractValidator<AddCommentRequestDto>
    {
        public AddCommentRequestValidator()
        {
            RuleFor(x => x.Comment)
                .NotNull().WithMessage("Comment is required.")
                .SetValidator(new CommentDtoValidator());

            RuleFor(x => x.ParentId)
                .Must(BeValidGuidOrNullOrEmpty)
                .WithMessage("ParentId must be a valid GUID if provided.");
        }

        private bool BeValidGuidOrNullOrEmpty(Guid? parentId)
        {
            if (!parentId.HasValue)
                return true;
            return true;
        }
    }

    public class CommentDtoValidator : AbstractValidator<CommentDto>
    {
        private const int MaxNameLength = 50;
        private const int MaxBodyLength = 500;
        private const string NamePattern = @"^[a-zA-Z0-9\s\-_]+$";

        public CommentDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(MaxNameLength).WithMessage($"Name must not exceed {MaxNameLength} characters.")
                .Matches(NamePattern).WithMessage("Name can only contain letters, numbers, spaces, hyphens, or underscores.");

            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Body is required.")
                .MaximumLength(MaxBodyLength).WithMessage($"Body must not exceed {MaxBodyLength} characters.");
        }
    }
}
