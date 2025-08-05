using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Games.GetGame
{
    public class PaginationGame
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public decimal Discount { get; set; }
        public int UnitInStock { get; set; }
    }
}
