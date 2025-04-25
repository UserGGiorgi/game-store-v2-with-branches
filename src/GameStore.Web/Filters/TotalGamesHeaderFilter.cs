using GameStore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace GameStore.Web.Filters
{
    public class TotalGamesHeaderFilter : IAsyncResultFilter
    {
        private readonly GameStoreDbContext _context;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "TotalGamesCount";
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(1);

        public TotalGamesHeaderFilter(
            GameStoreDbContext context
            , IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.Response.HasStarted)
            {
                var totalGames = await _cache.GetOrCreateAsync(CacheKey, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = CacheDuration;
                    return await _context.Games.CountAsync();
                });

                resultContext.HttpContext.Response.Headers.Append(
                    "x-total-numbers-of-games",
                    totalGames.ToString()
                );
            }
        }
    }

}
