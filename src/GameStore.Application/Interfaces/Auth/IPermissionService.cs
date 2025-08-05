
namespace GameStore.Application.Interfaces.Auth
{
    public interface IPermissionService
    {
        Task<IEnumerable<string>> GetUserRolesAsync(string email);
        Task<IEnumerable<string>> GetUserPermissionsAsync(string email);
    }
}
