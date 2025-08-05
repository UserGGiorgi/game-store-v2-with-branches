namespace GameStore.Application.Dtos.Genres.UpdateGenre
{
    public class UpdateGenreRequestDto
    {
        public GenreUpdateDto Genre { get; set; } = new();
    }
}
