using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByGameIdAsync(Guid gameId);
        Task<Comment?> GetCommentWithRepliesAsync(Guid commentId);
    }

}
