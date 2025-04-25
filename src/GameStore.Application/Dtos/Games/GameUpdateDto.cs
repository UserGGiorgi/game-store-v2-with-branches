using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Games
{
    public class GameUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public int UnitInStock { get; set; }
        public int Discount { get; set; }
    }
}
