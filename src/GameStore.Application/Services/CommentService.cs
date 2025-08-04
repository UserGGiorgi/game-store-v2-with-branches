using GameStore.Application.Dtos.Comments;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Enums;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using GameStore.Application.Dtos.Comments.CreateComment;

namespace GameStore.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CommentService> _logger;

        public CommentService(
            IUnitOfWork unitOfWork,
            ILogger<CommentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Comment> AddCommentAsync(string gameKey, AddCommentRequestDto dto)
        {
            var game = await _unitOfWork.GameRepository.GetByKeyAsync(gameKey)
                ?? throw new NotFoundException("Game not found");

            if (await IsUserBanned(dto.Comment.Name))
                throw new UnauthorizedException("User is banned from commenting");

            var comment = new Comment
            {
                Name = dto.Comment.Name,
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
                c.Status == CommentStatus.Deleted ? "A comment/quote was deleted" : FormatCommentBody(c),
                BuildCommentTree(c.Replies)
            )).ToList();
        }

        private static string FormatCommentBody(Comment comment)
        {
            if (comment.Status == CommentStatus.Deleted)
                return "A comment/quote was deleted";

            if (comment.ParentComment != null)
            {
                if (comment.ParentComment.Status == CommentStatus.Deleted)
                {
                    return $"[A comment was deleted], {comment.Body}";
                }

                if (comment.HasQuote)
                {
                    return $"[{comment.ParentComment.Body}], {comment.Body}";
                }
                else
                {
                    return $"[{comment.ParentComment.Name}], {comment.Body}";
                }
            }

            return comment.Body;
        }
    }
}