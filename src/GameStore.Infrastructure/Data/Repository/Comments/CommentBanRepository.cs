using GameStore.Domain.Entities.Comments;
using GameStore.Domain.Interfaces.Repositories.Comments;

namespace GameStore.Infrastructure.Data.Repository.Comments
{
    public class CommentBanRepository : GenericRepository<CommentBan>, ICommentBanRepository
    {
        public CommentBanRepository(GameStoreDbContext context) : base(context)
        {
        }
    }
}
