using GameStore.Application.Dtos.Authorization.Role.Create;
using GameStore.Application.Dtos.Authorization.Role.Get;
using GameStore.Application.Dtos.Authorization.Role.Update;
using GameStore.Application.Interfaces.Auth;
using GameStore.Domain.Entities.User;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class RoleService : IRoleService
    {
        private readonly GameStoreDbContext _context;

        public RoleService(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Select(r => new RoleDto(r.Id, r.Name))
                .ToListAsync();
        }

        public async Task<RoleDto?> GetById(Guid id)
        {
            return await _context.Roles
                .Where(r => r.Id == id)
                .Select(r => new RoleDto(r.Id, r.Name))
                .FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                return false;
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<string>> GetAllPermissionsAsync()
        {
            return await _context.Permissions
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToListAsync();
        }
        public async Task<List<string>?> GetRolePermissionsAsync(Guid roleId)
        {
            // Check if role exists
            if (!await _context.Roles.AnyAsync(r => r.Id == roleId))
            {
                return null;
            }

            return await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.Permission.Name)
                .OrderBy(name => name)
                .ToListAsync();
        }
        public async Task<AddRoleResult> AddRoleAsync(AddRoleRequestDto request)
        {
            // Validate role name
            if (string.IsNullOrWhiteSpace(request.Role.Name))
            {
                return new AddRoleResult
                {
                    Success = false,
                    Error = "Role name is required"
                };
            }

            // Check for duplicate role name
            if (await _context.Roles.AnyAsync(r => r.Name == request.Role.Name))
            {
                return new AddRoleResult
                {
                    Success = false,
                    Error = $"Role name already exists: {request.Role.Name}"
                };
            }

            // Get existing permissions
            var existingPermissions = await _context.Permissions
                .Where(p => request.Permissions.Contains(p.Name))
                .ToListAsync();

            // Check for missing permissions
            var existingPermissionNames = existingPermissions.Select(p => p.Name).ToList();
            var missingPermissions = request.Permissions.Except(existingPermissionNames).ToList();

            if (missingPermissions.Any())
            {
                return new AddRoleResult
                {
                    Success = false,
                    Error = $"Permissions not found: {string.Join(", ", missingPermissions)}"
                };
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Create new role
                var newRole = new Role
                {
                    Id = Guid.NewGuid(),
                    Name = request.Role.Name
                };

                _context.Roles.Add(newRole);

                // Add role permissions
                foreach (var permission in existingPermissions)
                {
                    _context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = newRole.Id,
                        PermissionId = permission.Id
                    });
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new AddRoleResult
                {
                    Success = true,
                    RoleId = newRole.Id
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new AddRoleResult
                {
                    Success = false,
                    Error = $"Role creation failed: {ex.Message}"
                };
            }
        }
        public async Task<UpdateRoleResult> UpdateRoleAsync(UpdateRoleRequestDto request)
        {
            // Validate request
            if (request.Role.Id == Guid.Empty)
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = "Role ID is required"
                };
            }

            if (string.IsNullOrWhiteSpace(request.Role.Name))
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = "Role name is required"
                };
            }

            // Get existing role with permissions
            var existingRole = await _context.Roles
                .Include(r => r.RolePermissions)
                .FirstOrDefaultAsync(r => r.Id == request.Role.Id);

            if (existingRole == null)
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Role not found: {request.Role.Id}"
                };
            }

            // Check for duplicate role name (if name changed)
            if (existingRole.Name != request.Role.Name &&
                await _context.Roles.AnyAsync(r => r.Name == request.Role.Name))
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Role name already exists: {request.Role.Name}"
                };
            }

            // Get existing permissions
            var existingPermissions = await _context.Permissions
                .Where(p => request.Permissions.Contains(p.Name))
                .ToListAsync();

            // Check for missing permissions
            var existingPermissionNames = existingPermissions.Select(p => p.Name).ToList();
            var missingPermissions = request.Permissions.Except(existingPermissionNames).ToList();

            if (missingPermissions.Any())
            {
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Permissions not found: {string.Join(", ", missingPermissions)}"
                };
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Update role name
                existingRole.Name = request.Role.Name;
                _context.Roles.Update(existingRole);

                // Get current permission IDs
                var currentPermissionIds = existingRole.RolePermissions
                    .Select(rp => rp.PermissionId)
                    .ToList();

                // Get new permission IDs
                var newPermissionIds = existingPermissions
                    .Select(p => p.Id)
                    .ToList();

                // Determine changes
                var permissionsToAdd = newPermissionIds.Except(currentPermissionIds).ToList();
                var permissionsToRemove = currentPermissionIds.Except(newPermissionIds).ToList();

                // Remove permissions
                if (permissionsToRemove.Any())
                {
                    var toRemove = existingRole.RolePermissions
                        .Where(rp => permissionsToRemove.Contains(rp.PermissionId))
                        .ToList();

                    _context.RolePermissions.RemoveRange(toRemove);
                }

                // Add new permissions
                foreach (var permissionId in permissionsToAdd)
                {
                    _context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = existingRole.Id,
                        PermissionId = permissionId
                    });
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new UpdateRoleResult { Success = true };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new UpdateRoleResult
                {
                    Success = false,
                    Error = $"Role update failed: {ex.Message}"
                };
            }
        }
    }
}
