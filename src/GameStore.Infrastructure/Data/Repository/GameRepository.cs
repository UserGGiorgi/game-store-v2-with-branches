using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreDbContext context) : base(context) { }
        public async Task<int> CountAsync()
        {
            return await _context.Games.CountAsync();
        }
        public async Task<Game?> GetByKeyAsync(string key)
        {
            return await _context.Games
                .Include(g => g.Genres)
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(g => g.Key == key);
        }

        public async Task<IEnumerable<Game>> GetGamesByGenreAsync(Guid genreId)
        {
            return await _context.Games
                .Include(g => g.Genres)
                    .ThenInclude(gg => gg.Genre)
                .Include(g => g.Platforms)   
                    .ThenInclude(gp => gp.Platform)
                .Where(g => g.Genres.Any(gg => gg.GenreId == genreId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesByPlatformAsync(Guid platformId)
        {
            return await _context.Games
                .Include(g => g.Platforms)
                    .ThenInclude(gp => gp.Platform)
                .Include(g => g.Genres) 
                    .ThenInclude(gg => gg.Genre)
                .Where(g => g.Platforms.Any(gp => gp.PlatformId == platformId))
                .ToListAsync();
        }
        //public async Task<IEnumerable<Game>> GetFilteredAsync(
        //Expression<Func<Game, bool>>? predicate = null,
        //Func<IQueryable<Game>, IOrderedQueryable<Game>>? orderBy = null,
        //int? skip = null,
        //int? take = null)
        //{
        //    IQueryable<Game> query = _context.Games
        //        .Include(g => g.Genres)
        //        .Include(g => g.Platforms);

        //    if (predicate != null)
        //        query = query.Where(predicate);

        //    if (orderBy != null)
        //        query = orderBy(query);

        //    if (skip.HasValue)
        //        query = query.Skip(skip.Value);

        //    if (take.HasValue)
        //        query = query.Take(take.Value);

        //    return await query.ToListAsync();
        //}

        public IQueryable<Game> GetAllAsQuerable()
        {
            return _context.Games.AsQueryable();
        }
    }
}
