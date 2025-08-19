namespace GameStore.Application.Dtos.Genres.GetGenre
{
    public class GenreDto
    {
        public string Name { get; set; } = string.Empty;
        public string? ParentGenreId { get; set; }
    }
}
