using GameStore.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class AccessService : IAccessService
    {
        private readonly IPermissionService _permissionService;
        private readonly IConfiguration _configuration;

        public AccessService(IPermissionService permissionService, IConfiguration configuration)
        {
            _permissionService = permissionService;
            _configuration = configuration;
        }

        public async Task<bool> CheckAccessAsync(string userEmail, string targetPage, string? targetId = null)
        {
            var permissionMappings = _configuration.GetSection("PermissionMappings").Get<Dictionary<string, string>>();
            ArgumentNullException.ThrowIfNull(permissionMappings);
            if (!permissionMappings.TryGetValue(targetPage, out var requiredPermission))
            {
                requiredPermission = $"View{targetPage}";
            }

            var permissions = await _permissionService.GetUserPermissionsAsync(userEmail);

            return permissions.Contains(requiredPermission, StringComparer.OrdinalIgnoreCase);
        }
    }
}
