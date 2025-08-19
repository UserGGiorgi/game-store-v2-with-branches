using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces.Repositories.Auth;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Data.Repository.Auth
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(GameStoreDbContext context) : base(context) { }

        public async Task<List<UserRole>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Set<UserRole>()
                .Where(ur => ur.UserId == userId)
                .ToListAsync();
        }
    }
}
