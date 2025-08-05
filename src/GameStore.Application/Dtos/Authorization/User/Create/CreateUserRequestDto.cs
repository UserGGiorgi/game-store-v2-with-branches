namespace GameStore.Application.Dtos.Authorization.User.Create
{
    public class CreateUserRequestDto
    {
        public UserInfoDto User { get; set; } = new UserInfoDto();
        public List<Guid> Roles { get; set; } = new List<Guid>();
        public string Password { get; set; } = string.Empty;
    }
}
