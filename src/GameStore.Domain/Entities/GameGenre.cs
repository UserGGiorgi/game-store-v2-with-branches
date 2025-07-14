namespace GameStore.Domain.Entities;

public class GameGenre
{
    public Guid GameId { get; set; }
    public Guid GenreId { get; set; }

    public Game Game { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}