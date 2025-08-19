using GameStore.Application.Dtos.Order.Update;
using GameStore.Application.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers.Orders
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderFacade _orderFacade;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            IOrderFacade orderFacade,
            ILogger<OrdersController> logger)
        {
            _orderFacade = orderFacade;
            _logger = logger;
        }
        [HttpPost("/games/{key}/buy")]
        [Authorize(Policy = "BuyGames")] 
        public async Task<IActionResult> AddToCart(string key)
        {
            await _orderFacade.AddToCartAsync(key);
            return Ok();
        }

        [HttpDelete("cart/{key}")]
        [Authorize(Policy = "BuyGames")] 
        public async Task<IActionResult> RemoveFromCart(string key)
        {
            await _orderFacade.RemoveFromCartAsync(key);
            _logger.LogInformation("Removed item with key {Key} from cart", key);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Policy = "ViewOrderHistory")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderFacade.GetPaidAndCancelledOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "ViewOrderHistory")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderFacade.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpGet("{id}/details")]
        [Authorize(Policy = "ViewOrderHistory")]
        public async Task<IActionResult> GetOrderDetails(Guid id)
        {
            var details = await _orderFacade.GetOrderDetailsAsync(id);
            return Ok(details);
        }
        [HttpGet("cart")]
        [Authorize(Policy = "BuyGames")]
        public async Task<IActionResult> GetCart()
        {
            var cartItems = await _orderFacade.GetCartAsync();
            return Ok(cartItems);
        }

        [HttpGet("payment-methods")]
        [Authorize(Policy = "BuyGames")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var methods = await _orderFacade.GetPaymentMethodsAsync();
            return Ok(new { paymentMethods = methods });
        }

        [HttpPatch("details/{id}/quantity")]
        [Authorize(Policy = "EditOrderDetails")]
        public async Task<IActionResult> UpdateOrderDetailQuantity(
            Guid id,
            [FromBody] UpdateQuantityDto dto)
        {
            await _orderFacade.UpdateOrderDetailQuantityAsync(id, dto.Count);
            return NoContent();
        }

        [HttpDelete("details/{id}")]
        [Authorize(Policy = "EditOrderDetails")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            await _orderFacade.DeleteOrderDetailAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/ship")]
        [Authorize(Policy = "UpdateOrderStatus")]
        public async Task<IActionResult> ShipOrder(Guid id)
        {
            await _orderFacade.ShipOrderAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/details/{key}")]
        [Authorize(Policy = "EditOrderDetails")]
        public async Task<IActionResult> AddGameToOrder(
            Guid id,
            string key)
        {
            await _orderFacade.AddGameToOrderAsync(id, key);
            return NoContent();
        }

        [HttpGet("history")]
        [Authorize(Policy = "ViewOrderHistory")]
        public async Task<IActionResult> GetOrdersHistory()
        {
            var orders = await _orderFacade.GetOrderHistory();
            return Ok(orders);
        }
    }
}

