using GameStore.Application.Dtos.Comments;
using GameStore.Application.Interfaces.Comments;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Comments;
using GameStore.Domain.Enums;
using GameStore.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.Comments
{
    public class BanService : IBanService
    {
        private readonly ILogger<BanService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public BanService(
            IUnitOfWork unitOfWork,
            ILogger<BanService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<string>> GetBanDurationsAsync()
        {
            var durations = new[] { "1 hour", "1 day", "1 week", "1 month", "permanent" };
            return Task.FromResult(durations.AsEnumerable());
        }

        public async Task BanUserAsync(BanUserDto banDto)
        {
            var duration = banDto.Duration switch
            {
                "1 hour" => BanDuration.OneHour,
                "1 day" => BanDuration.OneDay,
                "1 week" => BanDuration.OneWeek,
                "1 month" => BanDuration.OneMonth,
                "permanent" => BanDuration.Permanent,
                _ => throw new ArgumentException("Invalid duration")
            };

            var ban = new CommentBan
            {
                Username = banDto.User,
                Duration = duration,
                Expires = CalculateBanExpiration(duration),
                GameId = null
            };

            await _unitOfWork.CommentBanRepository.AddAsync(ban);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("User {Username} banned for {Duration}", banDto.User, banDto.Duration);
        }
        private static DateTime CalculateBanExpiration(BanDuration duration)
        {
            return duration switch
            {
                BanDuration.OneHour => DateTime.UtcNow.AddHours(1),
                BanDuration.OneDay => DateTime.UtcNow.AddDays(1),
                BanDuration.OneWeek => DateTime.UtcNow.AddDays(7),
                BanDuration.OneMonth => DateTime.UtcNow.AddMonths(1),
                BanDuration.Permanent => DateTime.MaxValue,
                _ => throw new ArgumentException("Invalid duration")
            };
        }
    }
}
