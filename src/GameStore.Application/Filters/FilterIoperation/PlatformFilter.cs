using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class PlatformFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (filter.PlatformIds != null && filter.PlatformIds.Any())
            {
                return query.Where(g => g.Platforms.Any(gp => filter.PlatformIds.Contains(gp.PlatformId)));
            }
            return query;
        }
    }
}
