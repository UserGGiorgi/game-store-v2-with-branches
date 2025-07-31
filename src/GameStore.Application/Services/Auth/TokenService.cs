using GameStore.Application.Interfaces.Auth;
using GameStore.Domain.Entities.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IPermissionService _permissionService;

        public TokenService(IConfiguration config, IPermissionService permissionService)
        {
            _config = config;
            _permissionService = permissionService;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim("userid", user.Id.ToString()), 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("sub", user.Id.ToString())
            };


            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var permissions = await _permissionService.GetUserPermissionsAsync(user.Email);
            foreach (var permission in permissions)
                claims.Add(new Claim("Permission", permission));
            var Jwtkey = _config["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(Jwtkey))
                throw new InvalidOperationException("jwt key is not configured.");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwtkey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}