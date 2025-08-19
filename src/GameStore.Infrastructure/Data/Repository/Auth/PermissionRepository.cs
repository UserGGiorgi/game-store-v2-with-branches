using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Auth
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(GameStoreDbContext context) : base(context)
        {
        }
        public async Task<List<Permission>> GetByNamesAsync(IEnumerable<string> names)
        {
            return await _context.Set<Permission>()
                .Where(p => names.Contains(p.Name))
                .ToListAsync();
        }
    }
}
