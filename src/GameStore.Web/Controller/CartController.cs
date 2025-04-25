using GameStore.Domain.Exceptions;
using GameStore.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("games/{key}/buy")]
        public async Task<IActionResult> AddToCart(string key)
        {
            try
            {
                await _cartService.AddToCartAsync(key);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("orders/cart/{key}")]
        public async Task<IActionResult> RemoveFromCart(string key)
        {
            try
            {
                await _cartService.RemoveFromCartAsync(key);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
