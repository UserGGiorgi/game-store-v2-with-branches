using GameStore.Application.Dtos.User.AuthDTOs;

namespace GameStore.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
