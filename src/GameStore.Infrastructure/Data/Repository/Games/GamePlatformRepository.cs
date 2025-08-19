using GameStore.Domain.Entities.Games;
using GameStore.Domain.Interfaces.Repositories.Games;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Games
{
    public class GamePlatformRepository : GenericRepository<GamePlatform>, IGamePlatformRepository
    {
        public GamePlatformRepository(GameStoreDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<GamePlatform>> GetByGameIdAsync(Guid gameId)
        {
            return await _context.GamePlatforms
                .Where(gp => gp.GameId == gameId)
                .ToListAsync();
        }
    }
}
