namespace GameStore.Domain.Entities;

public class Game
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Key { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int UnitInStock { get; set; }
    public int Discount { get; set; }
    public Guid PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<GameGenre> Genres { get; set; } = new List<GameGenre>();
    public ICollection<GamePlatform> Platforms { get; set; } = new List<GamePlatform>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<CommentBan> CommentBans { get; set; } = new List<CommentBan>();
}