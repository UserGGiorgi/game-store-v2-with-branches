using System.ComponentModel.DataAnnotations;

namespace GameStore.Application.DTOs.Games;

public class GameDto
{
    [Required, StringLength(50)]
    public string Name { get; set; }

    [Required, StringLength(20)]
    public string Key { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public double Price { get; set; }

    [Range(0, int.MaxValue)]
    public int UnitInStock { get; set; }

    [Range(0, 100)]
    public int Discount { get; set; }
}