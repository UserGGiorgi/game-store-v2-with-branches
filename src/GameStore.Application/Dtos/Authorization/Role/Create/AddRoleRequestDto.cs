namespace GameStore.Application.Dtos.Authorization.Role.Create
{
    public class AddRoleRequestDto
    {
        public RoleInfoDto Role { get; set; } = new RoleInfoDto();
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
