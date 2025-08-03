using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class PublisherFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (filter.PublisherIds != null && filter.PublisherIds.Count != 0)
            {
                return query.Where(g => filter.PublisherIds.Contains(g.PublisherId));
            }
            return query;
        }
    }
}
