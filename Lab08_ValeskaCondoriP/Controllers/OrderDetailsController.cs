using Lab08_ValeskaCondoriP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeskaCondoriP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public OrderDetailsController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    /* 
    // GET api/orderdetails/{id}/details
    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetOrderDetails(int id)
    {
        var details = await _uow.OrderDetails.GetProductsByOrderIdAsync(id);
        return Ok(details);
    }

    // GET api/orderdetails/{id}/total
    [HttpGet("{id}/total")]
    public async Task<IActionResult> GetTotalQuantity(int id)
    {
        var total = await _uow.OrderDetails.GetTotalQuantityByOrderIdAsync(id);
        return Ok(new { OrderId = id, TotalQuantity = total });
    }
    
    // GET api/orderdetails/with-products
    [HttpGet("with-products")]
    public async Task<IActionResult> GetOrdersWithProductDetails()
    {
        var result = await _uow.OrderDetails.GetOrdersWithProductDetailsAsync();
        return Ok(result);
    }
    
    // GET api/orderdetails/by-client/1
    [HttpGet("by-client/{clientId}")]
    public async Task<IActionResult> GetProductsByClientId(int clientId)
    {
        var result = await _uow.OrderDetails.GetProductsByClientIdAsync(clientId);
        if (!result.Any()) return NotFound($"No se encontraron productos para el cliente {clientId}");

        return Ok(result);
    }
    
    // GET api/orderdetails/by-product/2
    [HttpGet("by-product/{productId}")]
    public async Task<IActionResult> GetClientsByProductId(int productId)
    {
        var result = await _uow.OrderDetails.GetClientsByProductIdAsync(productId);
        if (!result.Any()) return NotFound($"No se encontraron clientes que hayan comprado el producto {productId}");
        return Ok(result);
    }
    */
}