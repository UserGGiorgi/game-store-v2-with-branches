using GameStore.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccessService> _logger;

        public AccessService(IPermissionService permissionService,
            IConfiguration configuration
            , ILogger<AccessService> logger)
        {
            _permissionService = permissionService;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<bool> CheckAccessAsync(string userEmail, string targetPage, string? targetId = null)
        {
            if (targetPage.Equals("Cart", StringComparison.OrdinalIgnoreCase) ||
                targetPage.Equals("AddToCart", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            var permissions = await _permissionService.GetUserPermissionsAsync(userEmail);

            var adminPermissions = new[] { "ManageUsers", "ManageRoles", "ManageGames", "ManageOrders" };
            if (adminPermissions.All(p => permissions.Contains(p, StringComparer.OrdinalIgnoreCase)))
            {
                _logger.LogInformation("Admin-level access granted");
                return true;
            }
            if (targetPage.Equals("Games", StringComparison.OrdinalIgnoreCase))
            {
                return permissions.Contains("ViewGames", StringComparer.OrdinalIgnoreCase);
            }

            var permissionMappings = _configuration.GetSection("PermissionMappings")
                .Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();

            if (permissionMappings.TryGetValue(targetPage, out var requiredPermission))
            {
                return permissions.Contains(requiredPermission, StringComparer.OrdinalIgnoreCase);
            }

            requiredPermission = $"Manage{targetPage}";
            if (permissions.Contains(requiredPermission, StringComparer.OrdinalIgnoreCase))
                return true;
            requiredPermission = $"View{targetPage}";
            return permissions.Contains(requiredPermission, StringComparer.OrdinalIgnoreCase);
        }
    }
}
