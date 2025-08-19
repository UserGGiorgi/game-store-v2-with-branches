
namespace GameStore.Application.Filters.SortOperation
{
    public interface ISortOperation<T>
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}
