using Lab08_ValeskaCondoriP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeskaCondoriP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public ProductsController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    /*
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _uow.Products.GetAllAsync();
        return Ok(products);
    }

    // GET api/products/filter?price=20
    [HttpGet("filter")]
    public async Task<IActionResult> GetByPrice([FromQuery] decimal price)
    {
        var products = await _uow.Products.GetByPriceGreaterThanAsync(price);
        return Ok(products);
    }
    
    // GET api/products/most-expensive ---- PRODUCTO MAS CARO
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await _uow.Products.GetMostExpensiveProductAsync();

        if (product == null)
            return NotFound(new { Message = "No hay productos en la base de datos" });

        return Ok(product);
    }
    
    // GET api/products/average-price
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await _uow.Products.GetAveragePriceAsync();
        return Ok(new { AveragePrice = average });
    }
    
    // GET api/products/no-description
    [HttpGet("no-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var products = await _uow.Products.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }
    */
}