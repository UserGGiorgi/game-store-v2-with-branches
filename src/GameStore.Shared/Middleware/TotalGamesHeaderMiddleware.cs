using GameStore.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
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
        private static int? _cachedCount;
        private static DateTime _lastCacheTime = DateTime.MinValue;

        public TotalGamesHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IGameRepository gameRepository)
        {
            if (_cachedCount == null || DateTime.UtcNow - _lastCacheTime > TimeSpan.FromMinutes(1))
            {
                _cachedCount = await gameRepository.CountAsync();
                _lastCacheTime = DateTime.UtcNow;
            }

            context.Response.Headers.Append("x-total-numbers-of-games", _cachedCount.Value.ToString());

            await _next(context);
        }
    }
}