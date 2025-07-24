using GameStore.Application.Dtos.Authorization.User;
using GameStore.Application.Dtos.User.AuthDTOs;
using GameStore.Application.Interfaces.Auth;
using GameStore.Domain.Entities.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly IPermissionService _permissionService;
        private readonly IConfiguration _configuration;

        public AuthService(
            IHttpClientFactory httpClientFactory,
            ITokenService tokenService,
            IPermissionService permissionService,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalAuth");
            _tokenService = tokenService;
            _permissionService = permissionService;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var url = _configuration["AuthorizationMicroservice:Auth"];
            var authResponse = await _httpClient.PostAsJsonAsync(url,
                new { email = request.Login, password = request.Password });

            if (!authResponse.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("Invalid credentials");

            var externalUser = await authResponse.Content.ReadFromJsonAsync<ExternalUserDto>();
            ArgumentNullException.ThrowIfNull(externalUser);
            var roles = await _permissionService.GetUserRolesAsync(externalUser.Email);

            var user = new ApplicationUser
            {
                Email = externalUser.Email,
                DisplayName = $"{externalUser.FirstName} {externalUser.LastName}",
            };

            return new LoginResponseDto
            {
                Token = await _tokenService.GenerateTokenAsync(user, roles),
                Email = user.Email,
                Roles = roles
            };
        }
    }
}
