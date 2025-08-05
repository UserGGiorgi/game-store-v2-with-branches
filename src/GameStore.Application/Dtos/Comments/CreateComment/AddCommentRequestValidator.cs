using FluentValidation;
using GameStore.Domain.Constraints.Comments;

namespace GameStore.Application.Dtos.Comments.CreateComment
{
    public class AddCommentRequestValidator : AbstractValidator<AddCommentRequestDto>
    {
        public AddCommentRequestValidator()
        {
            RuleFor(x => x.Comment)
                .NotNull().WithMessage(CommentValidationConstraints.Messages.CommentRequired)
                .SetValidator(new CommentDtoValidator());

            RuleFor(x => x.ParentId)
                .Must(BeValidGuidOrNullOrEmpty)
                .WithMessage(CommentValidationConstraints.Messages.ParentIdFormat);
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

        public CommentDtoValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage(CommentValidationConstraints.Messages.BodyRequired)
                .MaximumLength(CommentValidationConstraints.Limits.Body)
                .WithMessage(CommentValidationConstraints.Messages.BodyLength);
        }
    }
}
