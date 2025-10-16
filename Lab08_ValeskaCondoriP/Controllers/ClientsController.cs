using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeskaCondoriP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public ClientsController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    /*[HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _uow.Clients.GetAllAsync();
        return Ok(clients);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        var clients = await _uow.Clients.GetByNameAsync(name);
        return Ok(clients);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Client client)
    {
        await _uow.Clients.AddAsync(client);
        await _uow.SaveAsync();
        return Ok(client);
    }*/
    
    //consulta con AsNoTracking
    [HttpGet("with-orders")]
    public IActionResult GetClientsWithOrders()
    {
        var clientOrders = _uow.Clients.GetClientsWithOrders();
        return Ok(clientOrders);
    }
    
    //doble consulta
    [HttpGet("products-count")]
    public IActionResult GetClientsWithProductCount()
    {
        var result = _uow.Clients.GetClientsWithProductCount();
        return Ok(result);
    }
    
    //Consulta Avanzada con Filtros y Agrupación
    [HttpGet("sales-by-client")]
    public IActionResult GetSalesByClient()
    {
        var result = _uow.Clients.GetSalesByClient();
        return Ok(result);
    }
}