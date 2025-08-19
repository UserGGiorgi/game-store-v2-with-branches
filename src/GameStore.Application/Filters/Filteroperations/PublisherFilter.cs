using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.FilterOperations
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
