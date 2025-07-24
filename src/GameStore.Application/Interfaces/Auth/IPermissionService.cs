using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Auth
{
    public interface IPermissionService
    {
        Task<IEnumerable<string>> GetUserRolesAsync(string email);
        Task<IEnumerable<string>> GetUserPermissionsAsync(string email);
    }
}
