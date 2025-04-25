using GameStore.Application.Dtos.Order;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Data;
using GameStore.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly GameStoreDbContext _context;

    public PaymentsController(OrderService orderService, GameStoreDbContext context)
    {
        _orderService = orderService;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDto request)
    {
        try
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open)
                ?? throw new Exception("Cart is empty");

            return request.Method switch
            {
                "Bank" => await _orderService.ProcessBankPayment(order.Id),
                "IBox terminal" => Ok(await _orderService.ProcessIBoxPayment(order.Id)),
                "Visa" => await ProcessVisaPayment(order.Id, request.Model),
                _ => BadRequest("Invalid method")
            };
        }
        catch (Exception ex)
        {
            await CancelOrderAsync();
            return BadRequest(ex.Message);
        }
    }

    private async Task<IActionResult> ProcessVisaPayment(Guid orderId, VisaPaymentModelDto model)
    {
        if (model == null) return BadRequest("Visa details required");

        await _orderService.ProcessVisaPayment(orderId, model);
        return Ok(); // 200 OK
    }

    private async Task CancelOrderAsync()
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);

        if (order != null)
        {
            order.Status = OrderStatus.Cancelled;
            await _context.SaveChangesAsync();
        }
    }
}