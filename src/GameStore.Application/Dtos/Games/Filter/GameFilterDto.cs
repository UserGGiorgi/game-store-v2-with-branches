using GameStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Games.Filter
{
    public class GameFilterDto
    {
        public List<Guid>? Genres { get; set; }
        public List<Guid>? Platforms { get; set; }
        public List<Guid>? Publishers { get; set; }
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? DatePublishing { get; set; }

    }
}
