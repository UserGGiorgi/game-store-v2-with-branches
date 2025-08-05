using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class PriceFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (filter.MinPrice.HasValue)
            {
                query = query.Where(g => g.Price >= (double)filter.MinPrice.Value);
            }
            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(g => g.Price <= (double)filter.MaxPrice.Value);
            }
            return query;
        }
    }
}
