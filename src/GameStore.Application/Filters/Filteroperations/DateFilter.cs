using GameStore.Application.Dtos.Games.Filter;
using GameStore.Domain.Entities.Games;
using GameStore.Domain.Enums;

namespace GameStore.Application.Filters.FilterOperations
{
    public class DateFilter : IFilterOperation<Game>
    {
        public IQueryable<Game> Apply(IQueryable<Game> query, GameFilterDto filter)
        {
            if (string.IsNullOrWhiteSpace(filter.DatePublishing))
                return query;

            var timeSpan = filter.DatePublishing.Trim().ToLower() switch
            {
                "last week" => TimeSpan.FromDays(7),
                "last month" => TimeSpan.FromDays(30),
                "last year" => TimeSpan.FromDays(365),
                "2 years" => TimeSpan.FromDays(365 * 2),
                "3 years" => TimeSpan.FromDays(365 * 3),
                _ => (TimeSpan?)null
            };

            if (timeSpan.HasValue)
            {
                var cutoffDate = DateTime.UtcNow - timeSpan.Value;
                query = query.Where(g => g.CreatedAt >= cutoffDate);
            }

            return query;
        }
    }
}
