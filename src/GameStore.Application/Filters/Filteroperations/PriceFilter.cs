using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.FilterOperations
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
