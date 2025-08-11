using GameStore.Application.Dtos.Games.CreateGame;
using GameStore.Application.Dtos.Games.GetGames;

namespace GameStore.Application.Dtos.Games.CreateGames;

public class CreateGameRequestDto
{
    public CreateGameDto Game { get; set; } = default!;
    public List<Guid> Genres { get; set; } = new();
    public List<Guid> Platforms { get; set; } = new();
    public Guid Publisher { get; set; } = Guid.Empty;
}