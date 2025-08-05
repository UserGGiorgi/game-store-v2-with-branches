using GameStore.Domain.Entities.User;

namespace GameStore.Application.Interfaces.Auth
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user, IEnumerable<string> roles);
    }
}
