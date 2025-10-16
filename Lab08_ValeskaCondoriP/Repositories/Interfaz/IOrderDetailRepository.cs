using Lab08_ValeskaCondoriP.Models;

namespace Lab08_ValeskaCondoriP.Repositories.Interfaz;

public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    Task<IEnumerable<object>> GetProductsByOrderIdAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<IEnumerable<object>> GetOrdersWithProductDetailsAsync(); //Todos los Pedidos y sus Detalles 
    Task<IEnumerable<object>> GetProductsByClientIdAsync(int clientId); //Productos Vendidos por un Cliente 
    Task<IEnumerable<object>> GetClientsByProductIdAsync(int productId);//Clientes que Han Comprado un Producto 
}