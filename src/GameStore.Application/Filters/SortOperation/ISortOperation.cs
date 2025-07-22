using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.SortOperation
{
    public interface ISortOperation<T>
    {
        IQueryable<T> Apply(IQueryable<T> query);
    }
}
