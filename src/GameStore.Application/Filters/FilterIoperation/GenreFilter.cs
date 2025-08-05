using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class GenreFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (filter.Genres != null && filter.Genres.Count != 0)
            {
                return query.Where(g => g.Genres.Any(gg => filter.Genres.Contains(gg.GenreId)));
            }
            return query;
        }
    }
}
