namespace GameStore.Application.Dtos.Genres.UpdateGenre
{
    public class GenreUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ParentGenreId { get; set; }
    }
}
