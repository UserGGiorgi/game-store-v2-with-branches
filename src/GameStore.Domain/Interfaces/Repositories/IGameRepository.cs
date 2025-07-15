using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<int> CountAsync();
        Task<Game?> GetByKeyAsync(string key);
        Task<IEnumerable<Game>> GetGamesByPlatformAsync(Guid platformId);
        Task<IEnumerable<Game>> GetGamesByGenreAsync(Guid genreId);
        //Task<IEnumerable<Game>> GetFilteredAsync(
        //Expression<Func<Game, bool>>? predicate = null,
        //Func<IQueryable<Game>, IOrderedQueryable<Game>>? orderBy = null,
        //int? skip = null,
        //int? take = null);
        IQueryable<Game> GetAllAsQuerable();
    }
}
