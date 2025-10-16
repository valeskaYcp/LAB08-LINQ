using Lab08_ValeskaCondoriP.DTOs;
using Lab08_ValeskaCondoriP.Repositories.Interfaz;
using Lab08_ValeskaCondoriP.Services.Interfaces;

namespace Lab08_ValeskaCondoriP.Services.Implementaciones;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public IEnumerable<ClientOrderDto> GetClientsWithOrders()
    {
        return _clientRepository.GetClientsWithOrders();
    }

    public IEnumerable<object> GetClientsWithProductCount()
    {
        return _clientRepository.GetClientsWithProductCount();
    }

    public IEnumerable<SalesByClientDto> GetSalesByClient()
    {
        return _clientRepository.GetSalesByClient();
    }
}