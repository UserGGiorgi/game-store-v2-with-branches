using GameStore.Application.Dtos.Comments;
using GameStore.Application.Interfaces.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers.Comments
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        [HttpGet("/comments/ban/durations")]
        [Authorize(Policy = "BanCommenters")]
        public async Task<IActionResult> GetBanDurations()
        {
            var durations = await _banService.GetBanDurationsAsync();
            _logger.LogInformation("Retrieved ban durations: {Durations}", string.Join(", ", durations));
            return Ok(durations);
        }

        [HttpPost("/comments/ban")]
        [Authorize(Policy = "BanCommenters")]
        public async Task<IActionResult> BanUser([FromBody] BanUserDto banDto)
        {
            await _banService.BanUserAsync(banDto);
            return Ok();
        }
    }
}
