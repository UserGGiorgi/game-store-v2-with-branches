using GameStore.Application.Dtos.Games.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.FilterIoeration
{
    public interface IFilterOperation<T>
    {
        IQueryable<T> Apply(IQueryable<T> query, GameFilterDto filter);
    }
}
