using Lab08_ValeskaCondoriP.DTOs;
using Lab08_ValeskaCondoriP.Models;

namespace Lab08_ValeskaCondoriP.Repositories.Interfaz;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<object?> GetClientWithMostOrdersAsync(); //Cliente con Mayor Número de Pedidos
    IEnumerable<OrderDetailsDto> GetOrdersWithDetails(); //Include y ThenInclude
}