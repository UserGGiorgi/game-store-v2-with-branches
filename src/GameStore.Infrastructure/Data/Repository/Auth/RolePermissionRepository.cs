using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Auth
{
    public class RolePermissionRepository : GenericRepository<RolePermission> , IRolePermissionRepository
    {
        public RolePermissionRepository(GameStoreDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<RolePermission>> GetForRoleWithPermissionsAsync(Guid roleId)
        {
            return await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Include(rp => rp.Permission)
                .ToListAsync();
        }
    }
}
