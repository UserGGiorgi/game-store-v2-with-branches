using GameStore.Application.Interfaces.Auth;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
            return await _context.UserRoles
                .Where(ur => ur.UserEmail == email)
                .Select(ur => ur.Role.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUserPermissionsAsync(string email)
        {
            var roles = await _context.UserRoles
                .Where(ur => ur.UserEmail == email)
                .Include(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .ToListAsync();

            var permissions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var role in roles.Select(ur => ur.Role))
            {
                foreach (var permission in role.RolePermissions.Select(rp => rp.Permission.Name))
                {
                    permissions.Add(permission);
                }

                AddInheritedPermissions(role.Name, permissions);
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
                        .Select(rp => rp.Permission.Name)
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
