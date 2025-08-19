namespace GameStore.Application.Dtos.Authorization.Permission
{
    public class AccessCheckRequestDto
    {
        public string TargetPage { get; set; } = string.Empty;
        public string TargetId { get; set; } = string.Empty;
    }
}
