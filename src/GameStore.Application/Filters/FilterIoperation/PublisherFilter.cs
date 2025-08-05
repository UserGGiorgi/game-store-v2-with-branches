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
            if (filter.Publishers != null && filter.Publishers.Count != 0)
            {
                return query.Where(g => filter.Publishers.Contains(g.PublisherId));
            }
            return query;
        }
    }
}
