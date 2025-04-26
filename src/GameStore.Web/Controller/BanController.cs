using GameStore.Application.Dtos.Ban;
using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("comments/ban")]
    public class BanController : ControllerBase
    {
        private readonly IBanService _banService;

        public BanController(IBanService banService)
        {
            _banService = banService;
        }

        [HttpGet("durations")]
        public IActionResult GetBanDurations()
        {
            return Ok(_banService.GetBanDurations());
        }
        [HttpPost]
        public async Task<IActionResult> BanUser([FromBody] BanUserRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _banService.BanUserAsync(request.User, request.Duration);
                return Ok();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
