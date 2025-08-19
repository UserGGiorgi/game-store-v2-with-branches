using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Games
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre?> GetByNameAsync(string name);
        Task<IEnumerable<Genre>> GetGenresByGameKeyAsync(string gameKey);
        Task<IEnumerable<Genre>> GetSubGenresAsync(Guid parentId);
        Task<bool> HasSubGenresAsync(Guid parentId);
        Task<bool> IsAttachedToGamesAsync(Guid genreId);
    }
}
