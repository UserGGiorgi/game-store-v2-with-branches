using GameStore.Application.Dtos.Comments;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using GameStore.Application.Dtos.Comments.CreateComment;
using GameStore.Application.Interfaces.Comments;
using GameStore.Domain.Entities.Comments;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GameStore.Application.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CommentService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(
            IUnitOfWork unitOfWork,
            ILogger<CommentService> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Comment> AddCommentAsync(string gameKey, AddCommentRequestDto dto)
        {
            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            var displayName = GetUserDisplayName();

            if (await IsUserBanned(displayName))
                throw new UnauthorizedException("User is banned from commenting");

            var comment = new Comment
            {
                Name = displayName,
                Body = dto.Comment.Body,
                GameId = game.Id
            };

            if (dto.ParentId.HasValue)
            {
                var parent = await _unitOfWork.CommentRepository.GetByIdAsync(dto.ParentId.Value)
                    ?? throw new NotFoundException("Parent comment not found");

                comment.ParentCommentId = parent.Id;
                comment.HasQuote = dto.Action == CommentAction.Quote;

        
            }

            await _unitOfWork.CommentRepository.AddAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Comment added by {Username} for game {GameKey}", dto.Comment.Name, gameKey);
            return comment;
        }

        public async Task<IEnumerable<CommentResponseDto>> GetGameCommentsAsync(string gameKey)
        {
            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            var comments = await _unitOfWork.CommentRepository.GetCommentsByGameIdAsync(game.Id);
            return BuildCommentTree(comments.Where(c => c.ParentCommentId == null));
        }

        public async Task DeleteCommentAsync(Guid commentId)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(commentId)
                ?? throw new NotFoundException("Comment not found");

            comment.Status = CommentStatus.Deleted;
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<bool> IsUserBanned(string username)
        {
            var currentTime = DateTime.UtcNow;
            return await _unitOfWork.CommentBanRepository.AnyAsync(b =>
                b.Username == username &&
                b.Expires > currentTime);
        }

        private static List<CommentResponseDto> BuildCommentTree(IEnumerable<Comment> comments)
        {
            return comments.Select(c => new CommentResponseDto(
                c.Id,
                c.Name,
                FormatCommentBody(c),
                BuildCommentTree(c.Replies)
            )).ToList();
        }

        private static string FormatCommentBody(Comment comment)
        {
            if (comment.Status == CommentStatus.Deleted)
                return "A comment/quote was deleted";

            if (comment.ParentComment != null)
            {
                string parentContent;

                if (comment.ParentComment.Status == CommentStatus.Deleted)
                {
                    parentContent = "A comment/quote was deleted";
                }
                else
                {
                    parentContent = comment.HasQuote
                        ? comment.ParentComment.Body
                        : comment.ParentComment.Name;
                }

                return $"[{parentContent}], {comment.Body}";
            }

            return comment.Body;
        }
        private string GetUserDisplayName()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext?.User?.Identity?.IsAuthenticated != true)
            {
                throw new UnauthorizedException("User is not authenticated");
            }

            var displayName = httpContext.User.FindFirst("display_name")?.Value
                ?? httpContext.User.FindFirst(ClaimTypes.Name)?.Value
                ?? throw new UnauthorizedException("Display name not found in claims");

            return displayName;
        }
    }
}