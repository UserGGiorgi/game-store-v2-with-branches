using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
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
    }
}
