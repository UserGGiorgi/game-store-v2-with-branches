using System.ComponentModel.DataAnnotations;

namespace GameStore.Application.Dtos.Games.GetGames;

public class GameDto
{
    public string Name { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int UnitInStock { get; set; }
    public int Discount { get; set; }

}