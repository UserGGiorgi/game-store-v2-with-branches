using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(GameStoreDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByCompanyNameAsync(string companyName)
            => await _context.Publishers
                .AnyAsync(p => string.Equals(p.CompanyName, companyName, StringComparison.OrdinalIgnoreCase));

        public async Task<Publisher?> GetByCompanyNameAsync(string companyName)
            => await _context.Publishers
                .FirstOrDefaultAsync(p => string.Equals(p.CompanyName, companyName, StringComparison.OrdinalIgnoreCase));

        public async Task<Publisher?> GetByGameKeyAsync(string gameKey)
            => await _context.Publishers
                .Include(p => p.Games)
                .FirstOrDefaultAsync(p => p.Games.Any(g => g.Key == gameKey));

        public async Task<IEnumerable<Game>> GetGamesByPublisherNameAsync(string companyName)
            => await _context.Games
                .Where(g => string.Equals(g.Publisher.CompanyName, companyName, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();


        public async Task<bool> HasGamesAsync(Guid publisherId)
            => await _context.Games
                .AnyAsync(g => g.PublisherId == publisherId);

    }
}
