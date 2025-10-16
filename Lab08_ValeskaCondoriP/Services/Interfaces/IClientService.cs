using Lab08_ValeskaCondoriP.DTOs;

namespace Lab08_ValeskaCondoriP.Services.Interfaces;

public interface IClientService
{
    IEnumerable<ClientOrderDto> GetClientsWithOrders(); // AsNoTracking
    IEnumerable<object> GetClientsWithProductCount();   // Doble consulta
    IEnumerable<SalesByClientDto> GetSalesByClient();   // Consulta avanzada
}