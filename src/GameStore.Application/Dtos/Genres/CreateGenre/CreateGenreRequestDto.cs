using GameStore.Application.Dtos.Genres.GetGenre;

namespace GameStore.Application.Dtos.Genres.CreateGenre
{
    public class CreateGenreRequestDto
    {
        public GenreDto Genre { get; set; } = new();
    }

}
