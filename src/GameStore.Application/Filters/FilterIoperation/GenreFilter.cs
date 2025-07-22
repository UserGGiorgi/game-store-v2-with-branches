using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class GenreFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (filter.GenreIds != null && filter.GenreIds.Count != 0)
            {
                return query.Where(g => g.Genres.Any(gg => filter.GenreIds.Contains(gg.GenreId)));
            }
            return query;
        }
    }
}
