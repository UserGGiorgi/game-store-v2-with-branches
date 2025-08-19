
namespace GameStore.Application.Interfaces.Auth
{
    public interface IAccessService
    {
        Task<bool> CheckAccessAsync(string userEmail, string targetPage, string? targetId = null);
    }
}
