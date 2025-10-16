using Lab08_ValeskaCondoriP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeskaCondoriP.Controllers
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

        /*
        // GET api/orders/after?date=2025-05-01
        [HttpGet("after")]
        public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
        {
            var orders = await _orderService.GetOrdersAfterDateAsync(date);
            return Ok(orders);
        }

        // GET api/orders/client-most
        [HttpGet("client-most")]
        public async Task<IActionResult> GetClientWithMostOrders()
        {
            var result = await _orderService.GetClientWithMostOrdersAsync();
            if (result == null) return NotFound("No hay pedidos registrados.");

            return Ok(result);
        }
        */

        // Consulta con Include y ThenInclude
        [HttpGet("with-details")]
        public IActionResult GetOrdersWithDetails()
        {
            var orders = _orderService.GetOrdersWithDetails();
            return Ok(orders);
        }
    }
}