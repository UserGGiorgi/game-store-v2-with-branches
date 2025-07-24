using GameStore.Application.Dtos.Authorization.User;
using GameStore.Application.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public UserService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var externalUsers = await FetchExternalUsersAsync();
            return externalUsers.Select(u => new UserDto
            {
                Id = u.Email,
                Name = $"{u.FirstName} {u.LastName}"
            });
        }
        public async Task<UserDto?> GetUserByIdAsync(string email)
        {
            var allUsers = await GetAllUsersAsync();

            var user = allUsers.FirstOrDefault(u => u.Id.Equals(email, StringComparison.OrdinalIgnoreCase));

            return user;
        }

        private async Task<IEnumerable<ExternalUserDto>> FetchExternalUsersAsync()
        {
            var client = _httpClientFactory.CreateClient("ExternalAuth");
            var url = _configuration["AuthorizationMicroservice:Users"];
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch users: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<ExternalUserDto>>()
                   ?? Enumerable.Empty<ExternalUserDto>();
        }
    }
}
