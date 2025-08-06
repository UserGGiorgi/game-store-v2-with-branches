using GameStore.Application.Dtos.Comments;
using GameStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BanController : ControllerBase
    {
        private readonly ILogger<BanController> _logger;
        private readonly IBanService _banService;
        public BanController(
            IBanService banService,
            ILogger<BanController> logger)
        {
            _banService = banService;
            _logger = logger;
        }
        [HttpGet("durations")]
        public async Task<IActionResult> GetBanDurations()
        {
            var durations = await _banService.GetBanDurationsAsync();
            _logger.LogInformation("Retrieved ban durations: {Durations}", string.Join(", ", durations));
            return Ok(durations);
        }

        [HttpPost]
        public async Task<IActionResult> BanUser([FromBody] BanUserDto banDto)
        {
            await _banService.BanUserAsync(banDto);
            return Ok();
        }
    }
}
