using GameStore.Application.Dtos.Comments;

namespace GameStore.Application.Interfaces.Comments
{
    public interface IBanService
    {
        Task<IEnumerable<string>> GetBanDurationsAsync();
        Task BanUserAsync(BanUserDto banDto);
    }
}
