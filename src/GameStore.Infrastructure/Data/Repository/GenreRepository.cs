using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(GameStoreDbContext context) : base(context) { }

    public async Task<Genre?> GetByNameAsync(string name)
        => await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);

    public async Task<IEnumerable<Genre>> GetGenresByGameKeyAsync(string gameKey)
    {
        return await _context.Genres
            .Include(g => g.ParentGenre)
            .Where(g => g.Games.Any(gg => gg.Game.Key == gameKey))
            .ToListAsync();
    }

    public async Task<IEnumerable<Genre>> GetSubGenresAsync(Guid parentId)
    {
        return await _context.Genres
            .Include(g => g.ParentGenre)
        .Where(g => g.ParentGenreId == parentId)
            .ToListAsync();
    }

    public async Task<bool> HasSubGenresAsync(Guid parentId)
        => await _context.Genres.AnyAsync(g => g.ParentGenreId == parentId);

    public async Task<bool> IsAttachedToGamesAsync(Guid genreId)
        => await _context.GameGenres.AnyAsync(gg => gg.GenreId == genreId);
}