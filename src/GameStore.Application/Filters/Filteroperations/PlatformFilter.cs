using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.FilterOperations
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
