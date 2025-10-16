using Lab08_ValeskaCondoriP.DTOs;

namespace Lab08_ValeskaCondoriP.Services.Interfaces;

public interface IOrderService
{
    // Obtener pedidos con detalles de productos
    IEnumerable<OrderDetailsDto> GetOrdersWithDetails();
}