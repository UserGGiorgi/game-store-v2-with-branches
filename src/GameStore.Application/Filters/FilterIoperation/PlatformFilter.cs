using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities;
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
            if (filter.Platforms != null && filter.Platforms.Count != 0)
            {
                return query.Where(g => g.Platforms.Any(gp => filter.Platforms.Contains(gp.PlatformId)));
            }
            return query;
        }
    }
}
