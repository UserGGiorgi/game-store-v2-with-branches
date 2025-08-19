using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Auth
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(GameStoreDbContext context) : base(context) { }

        public async Task<ApplicationUser?> GetByIdWithRolesAsync(Guid id)
        {
            return await _context.Set<ApplicationUser>()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Set<ApplicationUser>()
                .AnyAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _context.Set<ApplicationUser>()
            .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
