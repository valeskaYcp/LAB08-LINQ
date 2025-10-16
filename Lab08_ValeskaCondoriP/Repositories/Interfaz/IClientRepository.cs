using Lab08_ValeskaCondoriP.DTOs;
using Lab08_ValeskaCondoriP.Models;

namespace Lab08_ValeskaCondoriP.Repositories.Interfaz;

    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetByNameAsync(string name);
        IEnumerable<ClientOrderDto> GetClientsWithOrders(); //AsNoTracking
        IEnumerable<object> GetClientsWithProductCount(); //doble consulta
        IEnumerable<SalesByClientDto> GetSalesByClient(); //consulta avanzada

    }

