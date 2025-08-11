using GameStore.Application.Dtos.Authorization.Role.Create;
using GameStore.Application.Dtos.Authorization.Role.Get;
using GameStore.Application.Dtos.Authorization.Role.Update;
using GameStore.Application.Interfaces.Auth;
using GameStore.Domain.Entities.User;
using GameStore.Domain.Enums;
using GameStore.Domain.Interfaces;
using System.Data;

namespace GameStore.Application.Services.Auth
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            return (await _unitOfWork.RoleRepository.GetAllAsync())
                .Select(r => new RoleDto(r.Id, r.Name));
        }

        public async Task<RoleDto?> GetById(Guid id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            return role != null ? new RoleDto(role.Id, role.Name) : null;
        }
        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            if (role == null) return false;

            _unitOfWork.RoleRepository.Delete(role);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<List<string>> GetAllPermissionsAsync()
        {
            return (await _unitOfWork.PermissionRepository.GetAllAsync())
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();
        }
        public async Task<List<string>?> GetRolePermissionsAsync(Guid roleId)
        {
            if (!await _unitOfWork.RoleRepository.ExistsAsync(roleId))
                return null;

            var rolePermissions = await _unitOfWork.RolePermissionRepository
                .GetForRoleWithPermissionsAsync(roleId);

            return rolePermissions
                .Where(rp => rp.Permission != null)
                .Select(rp => rp.Permission!.Name)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .OrderBy(name => name)
                .ToList();
        }
        public async Task<AddRoleResult> AddRoleAsync(AddRoleRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Role.Name))
            {
                return new AddRoleResult
                {
                    Success = false,
                    Error = "Role name is required"
                };
            }

            if (await _unitOfWork.RoleRepository.ExistsByNameAsync(request.Role.Name))
                return new AddRoleResult { Success = false, Error = $"Role name exists: {request.Role.Name}" };

            var permissions = await _unitOfWork.PermissionRepository.GetByNamesAsync(request.Permissions);

            var existingPermissionNames = permissions.Select(p => p.Name).ToList();
            var missingPermissions = request.Permissions.Except(existingPermissionNames).ToList();

            if (missingPermissions.Count != 0)
            {
                return new AddRoleResult
                {
                    Success = false,
                    Error = $"Permissions not found: {string.Join(", ", missingPermissions)}"
                };
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var role = new Role
                {
                    Id = Guid.NewGuid(),
                    Name = request.Role.Name
                };

                await _unitOfWork.RoleRepository.AddAsync(role);

                foreach (var permission in permissions)
                {
                    await _unitOfWork.RolePermissionRepository.AddAsync(new RolePermission
                    {
                        RoleId = role.Id,
                        PermissionId = permission.Id
                    });
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return new AddRoleResult
                {
                    Success = true,
                    RoleId = role.Id
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new AddRoleResult
                {
                    Success = false,
                    Error = $"Role creation failed: {ex.Message}"
                };
            }
        }
        public async Task<UpdateRoleResult> UpdateRoleAsync(UpdateRoleRequestDto request)
        {
            if (request.Role.Id == Guid.Empty)
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = "Role ID is required",
                    ErrorCode = UpdateRoleError.ValidationError
                };
            }

            if (string.IsNullOrWhiteSpace(request.Role.Name))
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = "Role name is required",
                    ErrorCode = UpdateRoleError.ValidationError
                };
            }

            var role = await _unitOfWork.RoleRepository.GetByIdWithPermissionsAsync(request.Role.Id);
            if (role == null)
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Role not found: {request.Role.Id}",
                    ErrorCode = UpdateRoleError.NotFound
                };
            }

            if (role.Name != request.Role.Name)
            {
                bool nameExists = await _unitOfWork.RoleRepository.ExistsByNameAsync(request.Role.Name, request.Role.Id);
                if (nameExists)
                {
                    return new UpdateRoleResult
                    {
                        Success = false,
                        Error = $"Role name already exists: {request.Role.Name}",
                        ErrorCode = UpdateRoleError.DuplicateName
                    };
                }
            }

            var permissions = await _unitOfWork.PermissionRepository.GetByNamesAsync(request.Permissions);
            var existingPermissionNames = permissions.Select(p => p.Name).ToList();
            var missingPermissions = request.Permissions.Except(existingPermissionNames).ToList();

            if (missingPermissions.Count != 0)
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Permissions not found: {string.Join(", ", missingPermissions)}",
                    ErrorCode = UpdateRoleError.MissingPermissions
                };
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                role.Name = request.Role.Name;
                _unitOfWork.RoleRepository.Update(role);

                var currentPermissionIds = role.RolePermissions
                    .Select(rp => rp.PermissionId)
                    .ToList();

                var newPermissionIds = permissions
                    .Select(p => p.Id)
                    .ToList();

                var permissionsToAdd = newPermissionIds.Except(currentPermissionIds).ToList();
                var permissionsToRemove = currentPermissionIds.Except(newPermissionIds).ToList();

                if (permissionsToRemove.Count != 0)
                {
                    var toRemove = role.RolePermissions
                        .Where(rp => permissionsToRemove.Contains(rp.PermissionId))
                        .ToList();

                    foreach (var rp in toRemove)
                    {
                        _unitOfWork.RolePermissionRepository.Delete(rp);
                    }
                }

                foreach (var permissionId in permissionsToAdd)
                {
                    await _unitOfWork.RolePermissionRepository.AddAsync(new RolePermission
                    {
                        RoleId = role.Id,
                        PermissionId = permissionId
                    });
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return new UpdateRoleResult { Success = true };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Role update failed: {ex.Message}",
                    ErrorCode = UpdateRoleError.UnexpectedError
                };
            }
        }

    }
}
