namespace GameStore.Domain.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid? ParentGenreId { get; set; }

    public Genre? ParentGenre { get; set; }
    public ICollection<Genre> SubGenres { get; set; } = new List<Genre>();
    public ICollection<GameGenre> Games { get; set; } = new List<GameGenre>();
}