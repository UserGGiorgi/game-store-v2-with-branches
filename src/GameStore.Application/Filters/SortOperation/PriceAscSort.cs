using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.SortOperation
{
    public class PriceAscSort : ISortOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query)
        {
            return query.OrderBy(g => g.Price);
        }
    }
}
