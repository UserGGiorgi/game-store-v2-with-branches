using GameStore.Domain.Entities.Games;
using GameStore.Domain.Interfaces.Repositories.Games;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Games;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
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