using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class NameFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Name) && filter.Name.Length >= 3)
            {
                return query.Where(g => g.Name.Contains(filter.Name));
            }
            return query;
        }
    }
}
