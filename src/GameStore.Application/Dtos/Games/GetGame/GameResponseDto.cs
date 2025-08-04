using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Games.GetGames
{
    public class GameResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int UnitInStock { get; set; }
        public int Discount { get; set; }
        public Guid PublisherId { get; set; }
        public List<Guid> Genres { get; set; } = new();
        public List<Guid> Platforms { get; set; } = new();

    }
}
