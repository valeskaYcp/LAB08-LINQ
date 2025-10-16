using Lab08_ValeskaCondoriP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeskaCondoriP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public OrdersController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    /*
    // GET api/orders/after?date=2025-05-01
    [HttpGet("after")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _uow.Orders.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }
    
    // GET api/orders/client-most
    [HttpGet("client-most")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var result = await _uow.Orders.GetClientWithMostOrdersAsync();
        if (result == null) return NotFound("No hay pedidos registrados.");

        return Ok(result);
    } */
    
    // Consulta con Include y ThenInclude
    [HttpGet("with-details")]
      public IActionResult GetOrdersWithDetails()
      {
          var orders = _uow.Orders.GetOrdersWithDetails();
          return Ok(orders);
      }

}