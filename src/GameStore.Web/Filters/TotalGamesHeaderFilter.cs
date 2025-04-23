using GameStore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Web.Filters
{
    public class TotalGamesHeaderFilter : IAsyncResultFilter
    {
        private readonly GameStoreDbContext _context;

        public TotalGamesHeaderFilter(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.Response.HasStarted)
            {
                var totalGames = await _context.Games.CountAsync();
                resultContext.HttpContext.Response.Headers.Append(
                    "x-total-numbers-of-games",
                    totalGames.ToString()
                );
            }
        }
    }

}
