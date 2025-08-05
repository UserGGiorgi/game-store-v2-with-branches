using GameStore.Domain.Entities.Comments;
using GameStore.Domain.Interfaces.Repositories.Comments;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Comments
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreDbContext context) : base(context) { }
        public async Task<IEnumerable<Comment>> GetCommentsByGameIdAsync(Guid gameId)
        {
            return await _context.Comments
            .Where(c => c.GameId == gameId)
            .AsNoTracking()
            .Include(c => c.ParentComment)
            .Include(c => c.Replies)
            .ThenInclude(r => r.Replies)
            .ToListAsync();
        }

        public async Task<Comment?> GetCommentWithRepliesAsync(Guid commentId)
        {
            return await _context.Comments
                .Include(c => c.Replies)
                .FirstOrDefaultAsync(c => c.Id == commentId);
        }
    }
}
