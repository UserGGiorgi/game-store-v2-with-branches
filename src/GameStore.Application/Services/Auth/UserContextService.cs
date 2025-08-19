using GameStore.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserContextService> _logger;

        public UserContextService(
            IHttpContextAccessor httpContextAccessor,
            ILogger<UserContextService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public Guid GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim =
                user?.FindFirst("userid") ??
                user?.FindFirst(ClaimTypes.NameIdentifier) ??
                user?.FindFirst("sub");

            if (userIdClaim == null)
            {
                var claims = user?.Claims
                    .Select(c => $"{c.Type}: {c.Value}");
                _logger.LogError("Missing user ID claim. Available claims: {@Claims}", claims);
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var userIdString = userIdClaim.Value;
            if (userIdString.Length == 35 && userIdString.EndsWith("00000"))
            {
                userIdString = string.Concat(userIdString.AsSpan(0, 35), "0");
            }

            if (!Guid.TryParse(userIdString, out var userId))
            {
                _logger.LogError("Invalid user ID format: {UserIdString}", userIdString);
                throw new UnauthorizedAccessException("Invalid user identity format");
            }

            return userId;
        }
    }
}
