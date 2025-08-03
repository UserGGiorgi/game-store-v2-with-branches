using GameStore.Domain.Interfaces.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.RepositoryCollection
{
    public class AuthRepositoryCollection
    {
        public Lazy<IRoleRepository> Roles { get; }
        public Lazy<IPermissionRepository> Permissions { get; }
        public Lazy<IRolePermissionRepository> RolePermissions { get; }
        public Lazy<IApplicationUserRepository> Users { get; }
        public Lazy<IUserRoleRepository> UserRoles { get; }

        public AuthRepositoryCollection(
            Lazy<IRoleRepository> roles,
            Lazy<IPermissionRepository> permissions,
            Lazy<IRolePermissionRepository> rolePermissions,
            Lazy<IApplicationUserRepository> users,
            Lazy<IUserRoleRepository> userRoles
            )
        {
            Roles = roles;
            Permissions = permissions;
            RolePermissions = rolePermissions;
            Users = users;
            UserRoles = userRoles;
        }
    }
}
