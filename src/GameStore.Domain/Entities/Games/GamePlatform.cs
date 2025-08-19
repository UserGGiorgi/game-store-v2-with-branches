namespace GameStore.Domain.Entities.Games;

public class GamePlatform
{
    public Guid GameId { get; set; }
    public Guid PlatformId { get; set; }

    public Game Game { get; set; } = null!;
    public Platform Platform { get; set; } = null!;
}