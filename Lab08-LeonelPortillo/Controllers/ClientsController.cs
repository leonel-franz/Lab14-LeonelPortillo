using System.Threading.Tasks;
using Lab08_LeonelPortillo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LeonelPortillo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    
    [HttpGet("by-name")]
    public async Task<IActionResult> GetByName([FromQuery] string name)
    {
        var result = await _clientService.GetClientsByNameAsync(name);
        return Ok(result);
    }

    
    [HttpGet("top-orders")]
    public async Task<IActionResult> GetTopClientWithMostOrders()
    {
        var result = await _clientService.GetTopClientWithMostOrdersAsync();
        if (result == null) return NotFound("No se encontraron pedidos.");
        return Ok(result);
    }

    
    [HttpGet("bought-product/{productId}")]
    public async Task<IActionResult> GetClientsByPurchasedProduct(int productId)
    {
        var result = await _clientService.GetClientsByPurchasedProductAsync(productId);
        return Ok(result);
    }
}