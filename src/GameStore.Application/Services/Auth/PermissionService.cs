using GameStore.Application.Interfaces.Auth;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class PermissionService : IPermissionService
    {
        private readonly GameStoreDbContext _context;

        public PermissionService(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string email)
        {

            var userId = await _context.ApplicationUser
                .Where(u => u.Email == email)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role!.Name)
                .Where(name => name != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUserPermissionsAsync(string email)
        {
            var userId = await _context.ApplicationUser
                .Where(u => u.Email == email)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .ThenInclude(r => r!.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .Where(ur => ur.Role != null)
                .ToListAsync();

            var permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var userRole in roles)
            {
                if (userRole.Role?.RolePermissions == null)
                    continue;

                foreach (var rolePermission in userRole.Role.RolePermissions)
                {
                    if (rolePermission?.Permission?.Name != null)
                    {
                        permissions.Add(rolePermission.Permission.Name);
                    }
                }

                if (userRole.Role.Name != null)
                {
                    AddInheritedPermissions(userRole.Role.Name, permissions);
                }
            }

            return permissions;
        }

        private void AddInheritedPermissions(string roleName, HashSet<string> permissions)
        {
            var hierarchy = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                ["Administrator"] = new[] { "Manager", "Moderator", "User" },
                ["Manager"] = new[] { "Moderator", "User" },
                ["Moderator"] = new[] { "User" }
            };

            if (hierarchy.TryGetValue(roleName, out var childRoles))
            {
                foreach (var childRole in childRoles)
                {
                    var childPermissions = _context.Roles
                        .Where(r => r.Name == childRole)
                        .SelectMany(r => r.RolePermissions)
                        .Where(rp => rp.Permission != null)
                        .Select(rp => rp.Permission!.Name)
                        .Where(name => name != null)
                        .ToList();

                    foreach (var permission in childPermissions)
                    {
                        permissions.Add(permission);
                    }
                    AddInheritedPermissions(childRole, permissions);
                }
            }
        }
    }
}
