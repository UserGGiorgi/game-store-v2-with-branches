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
        public List<Guid>? GenreIds { get; set; }
        public List<Guid>? PlatformIds { get; set; }
        public List<Guid>? PublisherIds { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public PublishDateOption? PublishDate { get; set; }
        public string? Name { get; set; }
    }
}
