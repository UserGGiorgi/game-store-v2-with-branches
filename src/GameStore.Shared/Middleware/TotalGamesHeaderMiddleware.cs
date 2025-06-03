using GameStore.Domain.Interfaces.Repositories;
using GameStore.Shared.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Shared.Middleware
{
    public class TotalGamesHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly TimeProvider _timeProvider;
        private readonly TotalGamesCacheOptions _options;

        public TotalGamesHeaderMiddleware(
            RequestDelegate next,
            IMemoryCache cache,
            TimeProvider timeProvider,
            IOptions<TotalGamesCacheOptions> options)
        {
            _next = next;
            _cache = cache;
            _timeProvider = timeProvider;
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context, IGameRepository gameRepository)
        {
            const string cacheKey = "TotalGamesCount";

            if (!_cache.TryGetValue(cacheKey, out int count))
            {
                count = await gameRepository.CountAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(_options.CacheExpirationMinutes));

                _cache.Set(cacheKey, count, cacheEntryOptions);
            }

            context.Response.Headers.Append("x-total-numbers-of-games", count.ToString());
            await _next(context);
        }
    }
}