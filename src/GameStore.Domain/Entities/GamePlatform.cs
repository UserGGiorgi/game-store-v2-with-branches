namespace GameStore.Domain.Entities;

public class GamePlatform
{
    public Guid GameId { get; set; }
    public Guid PlatformId { get; set; }

    public Game Game { get; set; } = null!;
    public Platform Platform { get; set; } = null!;
}