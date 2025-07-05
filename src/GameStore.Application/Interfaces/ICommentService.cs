using GameStore.Application.Dtos.Comments;
using GameStore.Application.Dtos.Comments.CreateComment;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(string gameKey, AddCommentRequestDto dto);
        Task<IEnumerable<CommentResponseDto>> GetGameCommentsAsync(string gameKey);
        Task DeleteCommentAsync(Guid commentId);
        Task<IEnumerable<string>> GetBanDurationsAsync();
        Task BanUserAsync(BanUserDto banDto);
    }
}
