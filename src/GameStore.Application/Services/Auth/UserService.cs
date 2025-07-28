using GameStore.Application.Dtos.Authorization.Role.Get;
using GameStore.Application.Dtos.Authorization.User;
using GameStore.Application.Dtos.Authorization.User.Create;
using GameStore.Application.Dtos.Authorization.User.Update;
using GameStore.Application.Interfaces.Auth;
using GameStore.Domain.Entities.User;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly GameStoreDbContext _dbContext;

        public UserService(IHttpClientFactory httpClientFactory, IConfiguration configuration, GameStoreDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _dbContext = dbContext;
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
        public async Task<bool> DeleteUserByIdAsync(string email)
        {
            var client = _httpClientFactory.CreateClient("ExternalAuth");
            var url = _configuration["AuthorizationMicroservice:Users"];
            ArgumentNullException.ThrowIfNull(url);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = new StringContent(
                    JsonSerializer.Serialize(email),
                    Encoding.UTF8,
                    "application/json")
            };
            var response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return false;
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Failed to delete user: {response.StatusCode}. Error: {await response.Content.ReadAsStringAsync()}"
                );
            }
            var user = await _dbContext.ApplicationUser.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new BadRequestException($"User not found: {email}");  
            }
            _dbContext.ApplicationUser.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<CreateUserResult> CreateUserAsync(CreateUserRequestDto request)
        {
            if (await _dbContext.ApplicationUser.AsNoTracking()
                .AnyAsync(u => u.Email == request.User.Email))
            {
                return new CreateUserResult
                {
                    Success = false,
                    Error = $"Email already exists: {request.User.Email}"
                };
            }

            var nameParts = request.User.Name.Split(' ', 2);
            var firstName = nameParts[0];
            var lastName = nameParts.Length > 1 ? nameParts[1] : string.Empty;

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var externalResponse = await CreateExternalUserAsync(firstName, lastName, request);
                if (!externalResponse.Success) return externalResponse;
                var userId = Guid.NewGuid();
                var appUser = new ApplicationUser
                {
                    Id = userId,
                    Email = request.User.Email,
                    DisplayName = request.User.Name
                };
                _dbContext.ApplicationUser.Add(appUser);

                var roleResult = await AddUserRolesAsync(userId, request.Roles);
                if (!roleResult.Success) return roleResult;

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return new CreateUserResult { Success = true, Email = request.User.Email };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new CreateUserResult
                {
                    Success = false,
                    Error = $"User creation failed: {ex.Message}"
                };
            }
        }
        public async Task<UpdateUserResult> UpdateUserAsync(UpdateUserRequestDto request)
        {
            var existingUser = await _dbContext.ApplicationUser
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)  // Include roles for proper tracking
                .FirstOrDefaultAsync(u => u.Id == request.User.Id);

            if (existingUser == null)
            {
                return new UpdateUserResult
                {
                    Success = false,
                    Error = $"User not found: {request.User.Id}"
                };
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                existingUser.DisplayName = request.User.Name;

                if (!string.IsNullOrEmpty(request.Password))
                {
                    var passwordResult = await UpdateExternalUserPasswordAsync(
                        existingUser.Email,
                        request.Password,
                        existingUser.DisplayName);

                    if (!passwordResult.Success) return passwordResult;
                }

                var roleResult = await UpdateUserRolesAsync(existingUser, request.Roles);
                if (!roleResult.Success) return roleResult;

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return new UpdateUserResult { Success = true };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new UpdateUserResult
                {
                    Success = false,
                    Error = $"User update failed: {ex.Message}"
                };
            }
        }

        private async Task<UpdateUserResult> UpdateExternalUserPasswordAsync(
            string email,
            string newPassword,
            string displayName)
        {
            var nameParts = displayName.Split(' ', 2);
            var firstName = nameParts[0];
            var lastName = nameParts.Length > 1 ? nameParts[1] : string.Empty;

            var client = _httpClientFactory.CreateClient("ExternalAuth");
            var baseUrl = _configuration["AuthorizationMicroservice:Users"];

            var queryParams = new Dictionary<string, string> { { "originalEmail", email } };
            var url = QueryHelpers.AddQueryString(baseUrl, queryParams);

            var updateRequest = new
            {
                email,
                firstName,
                lastName,
                password = newPassword,
                confirmPassword = newPassword
            };

            var response = await client.PutAsJsonAsync(url, updateRequest);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new UpdateUserResult
                {
                    Success = false,
                    Error = $"External service error: {response.StatusCode} - {errorContent}"
                };
            }

            return new UpdateUserResult { Success = true };
        }

        private async Task<UpdateUserResult> UpdateUserRolesAsync(
            ApplicationUser user,
            List<Guid> newRoleIds)
        {
            var existingRoles = await _dbContext.Roles
                .Where(r => newRoleIds.Contains(r.Id))
                .ToListAsync();

            var existingRoleIds = existingRoles.Select(r => r.Id).ToList();
            var missingRoleIds = newRoleIds.Except(existingRoleIds).ToList();

            if (missingRoleIds.Any())
            {
                return new UpdateUserResult
                {
                    Success = false,
                    Error = $"Roles not found: {string.Join(", ", missingRoleIds)}"
                };
            }

            var currentRoleIds = user.UserRoles.Select(ur => ur.RoleId).ToList();

            var rolesToRemove = user.UserRoles
                .Where(ur => !newRoleIds.Contains(ur.RoleId))
                .ToList();

            var rolesToAdd = newRoleIds
                .Except(currentRoleIds)
                .Select(roleId => new UserRole
                {
                    UserId = user.Id,
                    RoleId = roleId,
                    User = user,
                    Role = existingRoles.First(r => r.Id == roleId)
                })
                .ToList();

            foreach (var role in rolesToRemove)
            {
                _dbContext.UserRoles.Remove(role);
            }

            if (rolesToAdd.Any())
            {
                foreach (var role in rolesToAdd)
                {
                    user.UserRoles.Add(role);
                }
            }

            return new UpdateUserResult { Success = true };
        }
        public async Task<List<RoleDto>?> GetUserRolesAsync(Guid userId)
        {
            if (!await _dbContext.ApplicationUser.AnyAsync(u => u.Id == userId))
            {
                return null;
            }

            return await _dbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role)
                .Select(r => new RoleDto(r.Id, r.Name))
                .ToListAsync();
        }
        private async Task<CreateUserResult> CreateExternalUserAsync(string firstName, string lastName, CreateUserRequestDto request)
        {
            var externalUser = new
            {
                email = request.User.Email,
                firstName,
                lastName,
                password = request.Password,
                confirmPassword = request.Password
            };

            var client = _httpClientFactory.CreateClient("ExternalAuth");
            var url = _configuration["AuthorizationMicroservice:Users"];
            var response = await client.PostAsJsonAsync(url, externalUser);

            return response.IsSuccessStatusCode
                ? new CreateUserResult { Success = true }
                : new CreateUserResult
                {
                    Success = false,
                    Error = $"External service error: {response.StatusCode}"
                };
        }

        private async Task<CreateUserResult> AddUserRolesAsync(Guid userId, List<Guid> roleIds)
        {
            var existingRoleIds = await _dbContext.Roles
                .AsNoTracking()
                .Where(r => roleIds.Contains(r.Id))
                .Select(r => r.Id)
                .ToListAsync();

            var missingRoleIds = roleIds.Except(existingRoleIds).ToList();
            if (missingRoleIds.Any())
            {
                return new CreateUserResult
                {
                    Success = false,
                    Error = $"Roles not found: {string.Join(", ", missingRoleIds)}"
                };
            }

            foreach (var roleId in roleIds)
            {
                _dbContext.UserRoles.Add(new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                });
            }

            return new CreateUserResult { Success = true };
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
