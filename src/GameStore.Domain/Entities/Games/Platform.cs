namespace GameStore.Domain.Entities.Games;

public class Platform
{
    public Guid Id { get; set; }
    public required string Type { get; set; }

    public ICollection<GamePlatform> Games { get; set; } = new List<GamePlatform>();
}