using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.SortOperation
{
    public class PriceDescSort : ISortOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query)
        {
            return query.OrderByDescending(g => g.Price);
        }
    }
}
