namespace GameStore.Domain.Entities;

public class Game
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Key { get; set; }
    public string? Description { get; set; }

    public ICollection<GameGenre> Genres { get; set; } = new List<GameGenre>();
    public ICollection<GamePlatform> Platforms { get; set; } = new List<GamePlatform>();
}