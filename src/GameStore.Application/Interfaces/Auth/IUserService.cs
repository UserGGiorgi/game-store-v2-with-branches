using GameStore.Application.Dtos.Authorization.Role.Get;
using GameStore.Application.Dtos.Authorization.User;
using GameStore.Application.Dtos.Authorization.User.Create;
using GameStore.Application.Dtos.Authorization.User.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces.Auth
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(string id);
        Task<bool> DeleteUserByIdAsync(string id);
        Task<CreateUserResult> CreateUserAsync(CreateUserRequestDto request);
        Task<UpdateUserResult> UpdateUserAsync(UpdateUserRequestDto request);
        Task<List<RoleDto>?> GetUserRolesAsync(Guid userId);
    }
}
