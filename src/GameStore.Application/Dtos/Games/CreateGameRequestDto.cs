using System.ComponentModel.DataAnnotations;

namespace GameStore.Application.DTOs.Games;

public class CreateGameRequestDto
{
    [Required]
    public GameDto Game { get; set; }

    [Required, MinLength(1)]
    public List<Guid> Genres { get; set; }

    [Required, MinLength(1)]
    public List<Guid> Platforms { get; set; }

    [Required]
    public Guid Publisher { get; set; }
}