namespace GameStore.Application.DTOs.Games;

public class CreateGameRequestDto
{
    public GameDto Game { get; set; } = default!;
    public List<Guid> Genres { get; set; } = new();
    public List<Guid> Platforms { get; set; } = new();
}