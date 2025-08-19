namespace GameStore.Application.Dtos.Authorization.User.Create
{
    public class CreateUserResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Email { get; set; }
    }
}
