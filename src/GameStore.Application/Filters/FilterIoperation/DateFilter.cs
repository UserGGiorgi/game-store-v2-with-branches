using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities;
using GameStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Filters.FilterIoeration
{
    public class DateFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (filter.PublishDate.HasValue)
            {
                var dateFilter = DateTime.UtcNow.AddTicks(-1 * GetDateRangeTicks(filter.PublishDate.Value));
                query = query.Where(g => g.CreatedAt >= dateFilter);
            }
            return query;
        }

        private long GetDateRangeTicks(PublishDateOption option)
        {
            return option switch
            {
                PublishDateOption.LastWeek => TimeSpan.FromDays(7).Ticks,
                PublishDateOption.LastMonth => TimeSpan.FromDays(30).Ticks,
                PublishDateOption.LastYear => TimeSpan.FromDays(365).Ticks,
                PublishDateOption.TwoYears => TimeSpan.FromDays(365 * 2).Ticks,
                PublishDateOption.ThreeYears => TimeSpan.FromDays(365 * 3).Ticks,
                _ => throw new ArgumentOutOfRangeException(nameof(option), option, null)
            };
        }
    }
}
