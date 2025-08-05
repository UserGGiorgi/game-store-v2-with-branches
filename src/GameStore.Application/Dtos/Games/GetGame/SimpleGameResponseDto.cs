namespace GameStore.Application.Dtos.Games.GetGame
{
    public class SimpleGameResponseDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
