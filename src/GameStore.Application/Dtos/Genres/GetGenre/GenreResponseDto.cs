namespace GameStore.Application.Dtos.Genres.GetGenre
{
    public class GenreResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? ParentGenreId { get; set; }
        public string ParentGenreName { get; set; } = string.Empty;
    }
}
