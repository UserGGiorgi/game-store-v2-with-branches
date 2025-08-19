using GameStore.Domain.Enums;

namespace GameStore.Application.Dtos.Authorization.Role.Update
{
    public class UpdateRoleResult
    {
        public bool Success { get; set; }
        public UpdateRoleError ErrorCode { get; set; } = UpdateRoleError.None;
        public string? Error { get; set; }
    }
}
