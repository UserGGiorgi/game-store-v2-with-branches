using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Services
{
    // BanService.cs
    public class BanService : IBanService
    {
        private readonly GameStoreDbContext _context;

        public BanService(GameStoreDbContext context)
        {
            _context = context;
        }
        public IEnumerable<string> GetBanDurations()
        {
            return new List<string>
        {
            "1 hour",
            "1 day",
            "1 week",
            "1 month",
            "permanent"
        };
        }
        public async Task BanUserAsync(string userName, string duration)
        {
            // Validate duration
            var validDurations = new[] { "1 hour", "1 day", "1 week", "1 month", "permanent" };
            if (!validDurations.Contains(duration))
                throw new BadRequestException("Invalid ban duration");

            // Calculate end date
            var startDate = DateTime.UtcNow;
            var endDate = duration switch
            {
                "1 hour" => startDate.AddHours(1),
                "1 day" => startDate.AddDays(1),
                "1 week" => startDate.AddDays(7),
                "1 month" => startDate.AddMonths(1),
                "permanent" => (DateTime?)null,
                _ => throw new BadRequestException("Invalid duration")
            };

            var existingBan = await _context.Bans
                .FirstOrDefaultAsync(b => b.UserName == userName);

            if (existingBan != null)
            {
                existingBan.Duration = duration;
                existingBan.StartDate = startDate;
                existingBan.EndDate = endDate;
            }
            else
            {
                _context.Bans.Add(new Ban
                {
                    UserName = userName,
                    Duration = duration,
                    StartDate = startDate,
                    EndDate = endDate
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
