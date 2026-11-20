using System;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LeonelPortillo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

   
    [HttpGet("{orderId}/details")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        var result = await _orderService.GetOrderDetailsByOrderIdAsync(orderId);
        return Ok(result);
    }

    
    [HttpGet("{orderId}/total-quantity")]
    public async Task<IActionResult> GetTotalProductQuantity(int orderId)
    {
        var total = await _orderService.GetTotalProductQuantityByOrderIdAsync(orderId);
        return Ok(new { OrderId = orderId, CantidadTotal = total });
    }

    
    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var result = await _orderService.GetOrdersAfterDateAsync(date);
        return Ok(result);
    }

    
    [HttpGet("all-with-details")]
    public async Task<IActionResult> GetAllOrdersWithDetails()
    {
        var result = await _orderService.GetAllOrdersWithDetailsAsync();
        return Ok(result);
    }

    
    [HttpGet("products-by-client/{clientId}")]
    public async Task<IActionResult> GetProductsSoldToClient(int clientId)
    {
        var result = await _orderService.GetProductsSoldToClientAsync(clientId);
        return Ok(result);
    }
}