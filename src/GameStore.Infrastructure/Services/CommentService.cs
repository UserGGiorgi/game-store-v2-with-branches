using AutoMapper;
using GameStore.Application.Dtos.Comment;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    // CommentService.cs
    public class CommentService : ICommentService
    {
        private readonly GameStoreDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(GameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentResponseDto> AddCommentAsync(
            string gameKey,
            CreateCommentDto commentDto,
            Guid? parentId = null)
        {
            var isBanned = await _context.Bans
        .AnyAsync(b => b.UserName == commentDto.Name &&
            (b.EndDate == null || b.EndDate > DateTime.UtcNow));

            if (isBanned)
                throw new BadRequestException("User is banned from posting comments");

            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Key == gameKey)
                ?? throw new NotFoundException("Game not found");

            if (parentId.HasValue)
            {
                var parentComment = await _context.Comments
                    .FirstOrDefaultAsync(c => c.Id == parentId.Value);

                if (parentComment == null)
                    throw new BadRequestException("Parent comment not found");
            }

            var comment = new Comment
            {
                Name = commentDto.Name,
                Body = commentDto.Body,
                GameId = game.Id,
                ParentCommentId = parentId,
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return _mapper.Map<CommentResponseDto>(comment);
        }

        public async Task<IEnumerable<CommentResponseDto>> GetCommentsByGameKeyAsync(string gameKey)
        {
            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Key == gameKey)
                ?? throw new NotFoundException("Game not found");

            var comments = await _context.Comments
                .Where(c => c.GameId == game.Id)
                .ToListAsync();

            var commentDict = comments.ToDictionary(c => c.Id);
            foreach (var comment in comments)
            {
                if (comment.ParentCommentId.HasValue &&
                    commentDict.TryGetValue(comment.ParentCommentId.Value, out var parent))
                {
                    parent.ChildComments.Add(comment);
                }
            }

            var topLevelComments = comments
                .Where(c => c.ParentCommentId == null)
                .ToList();

            return _mapper.Map<List<CommentResponseDto>>(topLevelComments);
        }
        public async Task DeleteCommentAsync(string gameKey, Guid commentId)
        {
            var game = await _context.Games
                .FirstOrDefaultAsync(g => g.Key == gameKey)
                ?? throw new NotFoundException("Game not found");

            var comment = await _context.Comments
                .Include(c => c.ChildComments)
                .FirstOrDefaultAsync(c =>
                    c.Id == commentId &&
                    c.GameId == game.Id)
                ?? throw new NotFoundException("Comment not found");

            if (comment.ChildComments.Any())
                throw new BadRequestException("Cannot delete comment with child comments");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
