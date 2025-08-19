namespace GameStore.Application.Dtos.Games.UpdateGames
{
    public class UpdateGameRequestDto
    {
        public GameUpdateDto Game { get; set; } = default!;
        public List<Guid> Genres { get; set; } = new();
        public List<Guid> Platforms { get; set; } = new();
        public Guid Publisher { get; set; }
    }
}
