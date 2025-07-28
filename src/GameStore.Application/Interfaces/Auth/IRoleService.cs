using GameStore.Application.Dtos.Authorization.Role.Create;
using GameStore.Application.Dtos.Authorization.Role.Get;
using GameStore.Application.Dtos.Authorization.Role.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Auth
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto?> GetById(Guid id);
        Task<bool> DeleteRoleAsync(Guid id);
        Task<List<string>> GetAllPermissionsAsync();
        Task<List<string>?> GetRolePermissionsAsync(Guid roleId);
        Task<AddRoleResult> AddRoleAsync(AddRoleRequestDto request);
        Task<UpdateRoleResult> UpdateRoleAsync(UpdateRoleRequestDto request);
    }
}
