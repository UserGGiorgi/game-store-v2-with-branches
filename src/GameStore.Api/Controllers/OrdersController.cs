using FluentValidation;
using GameStore.Application.Dtos.Genres.UpdateGenre;
using GameStore.Application.Dtos.Order;
using GameStore.Application.Dtos.Order.PaymentModels;
using GameStore.Application.Dtos.Order.PaymentRequest;
using GameStore.Application.Dtos.Order.PaymentResults;
using GameStore.Application.Dtos.Order.Update;
using GameStore.Application.Facade;
using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using GameStore.Application.Services.Payment;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System.Security.Claims;
using System.Threading;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> AddToCart(string key)
        {
            await _orderFacade.AddToCartAsync(key);
            return Ok();
        }

        [HttpDelete("cart/{key}")]
        public async Task<IActionResult> RemoveFromCart(string key)
        {
            await _orderFacade.RemoveFromCartAsync(key);
            _logger.LogInformation("Removed item with key {Key} from cart", key);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderFacade.GetPaidAndCancelledOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderFacade.GetOrderByIdAsync(id);
            return Ok(order);
        }
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetOrderDetails(Guid id)
        {
            var details = await _orderFacade.GetOrderDetailsAsync(id);
            return Ok(details);
        }
        [HttpGet("cart")]
        public async Task<IActionResult> GetCart()
        {
            var cartItems = await _orderFacade.GetCartAsync();
            return Ok(cartItems);
        }

        [HttpGet("payment-methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var methods = await _orderFacade.GetPaymentMethodsAsync();
            return Ok(new { paymentMethods = methods });
        }
        // I changed it because of some reasons ,task was:/orders/details/{id}/quantity
        [HttpPatch("details/{orderId}/{productId}/quantity")]
        public async Task<IActionResult> UpdateOrderDetailQuantity(
            Guid orderId,
            Guid productId,
            [FromBody] UpdateQuantityDto dto)
        {
            await _orderFacade.UpdateOrderDetailQuantityAsync(orderId, productId, dto.Count);
            return NoContent();
        }
        [HttpDelete("details/{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid orderId, Guid productId)
        {
            await _orderFacade.DeleteOrderDetailAsync(orderId, productId);
            return NoContent();
        }
        [HttpPost("{id}/ship")]
        public async Task<IActionResult> ShipOrder(Guid id)
        {
            await _orderFacade.ShipOrderAsync(id);
            return NoContent();
        }
        [HttpPost("{orderId}/details/{gameKey}")]
        public async Task<IActionResult> AddGameToOrder(
            Guid orderId,
            string gameKey)
        {
            await _orderFacade.AddGameToOrderAsync(orderId, gameKey);
            return NoContent();
        }
    }
}

