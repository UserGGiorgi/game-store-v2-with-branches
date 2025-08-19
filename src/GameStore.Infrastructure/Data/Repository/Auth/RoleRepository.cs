using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Auth
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(GameStoreDbContext context) : base(context)
        { 
        }
        public async Task<Role?> GetByIdWithPermissionsAsync(Guid id)
        {
            return await _context.Set<Role>()
                .Include(r => r.RolePermissions)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Set<Role>()
                .AnyAsync(r => r.Name == name);
        }
        public async Task<bool> ExistsByNameAsync(string name, Guid excludeRoleId)
        {
            return await _context.Roles
                .AnyAsync(r => r.Name == name && r.Id != excludeRoleId);
        }
    }
}
