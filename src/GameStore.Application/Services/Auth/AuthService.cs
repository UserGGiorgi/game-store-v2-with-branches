using GameStore.Application.Dtos.Authorization.User;
using GameStore.Application.Dtos.User.AuthDTOs;
using GameStore.Application.Interfaces.Auth;
using GameStore.Domain.Entities.User;
using GameStore.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace GameStore.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly IPermissionService _permissionService;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(
            IHttpClientFactory httpClientFactory,
            ITokenService tokenService,
            IPermissionService permissionService,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalAuth");
            _tokenService = tokenService;
            _permissionService = permissionService;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var url = _configuration["AuthorizationMicroservice:Auth"];
            var authResponse = await _httpClient.PostAsJsonAsync(url,
                new { email = request.Model.Login, password = request.Model.Password });

            if (!authResponse.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("Invalid credentials");

            var externalUser = await authResponse.Content.ReadFromJsonAsync<ExternalUserDto>();
            ArgumentNullException.ThrowIfNull(externalUser);
            var roles = await _permissionService.GetUserRolesAsync(externalUser.Email);

            var ApplicationUser = await _unitOfWork.ApplicationUserRepository.GetByEmailAsync(externalUser.Email);

            var user = new ApplicationUser
            {
                Id = ApplicationUser?.Id ?? Guid.NewGuid(),
                Email = externalUser.Email,
                DisplayName = $"{externalUser.FirstName} {externalUser.LastName}",
            };

            var token = await _tokenService.GenerateTokenAsync(user, roles);

            return new LoginResponseDto
            {
                Token = "Bearer " + token,
                Email = user.Email,
                Roles = roles
            };
        }
    }
}
