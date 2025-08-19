using GameStore.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth.PermissionRequirement
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; }

        public PermissionRequirement(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly ILogger<PermissionAuthorizationHandler> _logger;

        public PermissionAuthorizationHandler(
            GameStoreDbContext dbContext,
            ILogger<PermissionAuthorizationHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            try
            {
                var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    _logger.LogWarning("Missing or invalid user ID claim");
                    return;
                }

                _logger.LogDebug("Checking permission {Permission} for user {UserId}",
                    requirement.PermissionName, userId);

                var hasPermission = await _dbContext.UserRoles
                    .Where(ur => ur.UserId == userId)
                    .Join(_dbContext.RolePermissions,
                        ur => ur.RoleId,
                        rp => rp.RoleId,
                        (ur, rp) => rp.PermissionId)
                    .Join(_dbContext.Permissions,
                        permissionId => permissionId,
                        p => p.Id,
                        (permissionId, p) => p.Name)
                    .AnyAsync(p => p == requirement.PermissionName);

                if (hasPermission)
                {
                    _logger.LogDebug("Permission granted: {Permission} for user {UserId}",
                        requirement.PermissionName, userId);
                    context.Succeed(requirement);
                }
                else
                {
                    _logger.LogWarning("Permission denied: User {UserId} lacks {Permission}",
                        userId, requirement.PermissionName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking permission {Permission}",
                    requirement.PermissionName);
            }
        }
    }
}

