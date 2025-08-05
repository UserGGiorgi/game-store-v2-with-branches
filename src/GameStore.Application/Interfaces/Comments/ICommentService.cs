using GameStore.Application.Dtos.Comments;
using GameStore.Application.Dtos.Comments.CreateComment;
using GameStore.Domain.Entities.Comments;

namespace GameStore.Application.Interfaces.Comments
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(string gameKey, AddCommentRequestDto dto);
        Task<IEnumerable<CommentResponseDto>> GetGameCommentsAsync(string gameKey);
        Task DeleteCommentAsync(Guid commentId);
    }
}
