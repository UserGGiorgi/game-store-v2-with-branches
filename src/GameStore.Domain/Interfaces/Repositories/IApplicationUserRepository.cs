using GameStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces.Repositories
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser?> GetByIdWithRolesAsync(Guid id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<ApplicationUser?> GetByEmailAsync(string email);
    }
}
