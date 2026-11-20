using System.Threading.Tasks;
using Lab08_LeonelPortillo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_LeonelPortillo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    
    [HttpGet("price-greater-than/{price}")]
    public async Task<IActionResult> GetProductsPriceGreaterThan(decimal price)
    {
        var result = await _productService.GetProductsPriceGreaterThanAsync(price);
        return Ok(result);
    }

    
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var result = await _productService.GetMostExpensiveProductAsync();
        if (result == null) return NotFound("No hay productos registrados.");
        return Ok(result);
    }

    
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var avg = await _productService.GetAveragePriceAsync();
        return Ok(new { PromedioPrecio = avg });
    }

    
    [HttpGet("no-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var result = await _productService.GetProductsWithoutDescriptionAsync();
        return Ok(result);
    }
}