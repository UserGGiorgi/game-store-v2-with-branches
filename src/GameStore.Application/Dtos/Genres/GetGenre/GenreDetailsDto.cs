namespace GameStore.Application.Dtos.Genres.GetGenre
{
    public class GenreDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? ParentGenreId { get; set; }
    }
}
