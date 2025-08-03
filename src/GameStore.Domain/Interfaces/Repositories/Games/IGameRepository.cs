using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories.Games
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<int> CountAsync();
        Task<Game?> GetByKeyAsync(string key);
        Task<IEnumerable<Game>> GetGamesByPlatformAsync(Guid platformId);
        Task<IEnumerable<Game>> GetGamesByGenreAsync(Guid genreId);
        IQueryable<Game> GetAllAsQuerable();
    }
}
