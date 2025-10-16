using Lab08_ValeskaCondoriP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeskaCondoriP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    /* Endpoint para obtener todos los clientes
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _clientService.GetAllAsync();
        return Ok(clients);
    }

    // Buscar clientes por nombre
    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        var clients = await _clientService.GetByNameAsync(name);
        return Ok(clients);
    }

    // Crear un cliente
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Client client)
    {
        await _clientService.AddAsync(client);
        return Ok(client);
    }*/

    // Consulta con AsNoTracking
    [HttpGet("with-orders")]
    public IActionResult GetClientsWithOrders()
    {
        var clientOrders = _clientService.GetClientsWithOrders();
        return Ok(clientOrders);
    }

    // Doble consulta: total de productos por cliente
    [HttpGet("products-count")]
    public IActionResult GetClientsWithProductCount()
    {
        var result = _clientService.GetClientsWithProductCount();
        return Ok(result);
    }

    // Consulta avanzada: total de ventas por cliente
    [HttpGet("sales-by-client")]
    public IActionResult GetSalesByClient()
    {
        var result = _clientService.GetSalesByClient();
        return Ok(result);
    }
}
