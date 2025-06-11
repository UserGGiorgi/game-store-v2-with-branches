using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infrastructure.Data.Repository;
using GameStore.Shared.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repositories;

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
    public async Task<bool> IsCircularHierarchyAsync(Guid genreId, Guid parentGenreId)
    {
        var query = @"
        WITH GenreHierarchy AS (
        SELECT Id, ParentGenreId
        FROM Genres
        WHERE Id = @parentGenreId
        
        UNION ALL
        
        SELECT g.Id, g.ParentGenreId
        FROM Genres g
        INNER JOIN GenreHierarchy gh ON g.Id = gh.ParentGenreId
        )
        SELECT COUNT(*) AS Count
        FROM GenreHierarchy
        WHERE Id = @genreId";

        var parameters = new[]
        {
        new SqlParameter("@parentGenreId", parentGenreId),
        new SqlParameter("@genreId", genreId)
    };

        var result = await _context.Database
            .SqlQueryRaw<HierarchyCheckResult>(query, parameters)
            .FirstOrDefaultAsync();

        return result?.Count > 0;
    }
}