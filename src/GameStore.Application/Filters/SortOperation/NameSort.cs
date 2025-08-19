using GameStore.Domain.Entities.Games;

namespace GameStore.Application.Filters.SortOperation
{
    public class NameSort : ISortOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query)
        {
            return query.OrderBy(g => g.Name);
        }
    }
}
