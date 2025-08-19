namespace GameStore.Application.Dtos.Authorization.User.Update
{
    public class UpdateUserInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
