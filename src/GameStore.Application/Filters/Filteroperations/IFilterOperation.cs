using GameStore.Application.Dtos.Games.Filter;

namespace GameStore.Application.Filters.FilterOperations
{
    public interface IFilterOperation<T>
    {
        IQueryable<T> Apply(IQueryable<T> query, GameFilterDto filter);
    }
}
