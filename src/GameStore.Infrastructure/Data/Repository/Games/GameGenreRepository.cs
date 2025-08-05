using GameStore.Domain.Entities.Games;
using GameStore.Domain.Interfaces.Repositories.Games;
using Microsoft.EntityFrameworkCore;
namespace GameStore.Infrastructure.Data.Repository.Games
{
    public class GameGenreRepository : GenericRepository<GameGenre>, IGameGenreRepository
    {
        public GameGenreRepository(GameStoreDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<GameGenre>> GetByGameIdAsync(Guid gameId)
        {
            return await _context.GameGenres
                .Where(gg => gg.GameId == gameId)
                .ToListAsync();
        }
    }
}
