using System.ComponentModel.DataAnnotations;

namespace GameStore.Application.DTOs.Games;

public class CreateGameRequestDto
{
    [Required]
    public GameDto Game { get; set; } = new GameDto();

    [Required, MinLength(1)]
    public List<Guid> Genres { get; set; } = new List<Guid>();

    [Required, MinLength(1)]
    public List<Guid> Platforms { get; set; } = new List<Guid> { Guid.Empty };

    [Required]
    public Guid Publisher { get; set; }
}