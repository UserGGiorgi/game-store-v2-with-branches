using GameStore.Application.Interfaces;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetPaidAndCancelledOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetOrderDetails(Guid id)
        {
            try
            {
                var details = await _orderService.GetOrderDetailsAsync(id);
                return Ok(details);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("cart")]
        public async Task<IActionResult> GetCart()
        {
            var cartItems = await _orderService.GetCartAsync();
            return Ok(cartItems);
        }
        [HttpGet("payment-methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var methods = await _orderService.GetPaymentMethodsAsync();
            return Ok(new { paymentMethods = methods });
        }

    }
}
