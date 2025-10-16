using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.Repositories.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ValeskaCondoriP.Repositories.Implementacion;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    private readonly AppDbContext _context;

    public OrderDetailRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetProductsByOrderIdAsync(int orderId)
    {
        var query = await _context.OrderDetails
            .Where(od => od.OrderId == orderId)       //filtrar por OrderId
            .Select(od => new 
            {
                ProductName = od.Product.Name,        //mostrar nombre del producto
                Quantity = od.Quantity                //mostrar cantidad
            })
            .ToListAsync();

        return query;
    }
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)   // filtra por OrderId
            .Select(od => od.Quantity)            // proyecta cantidad
            .SumAsync();                          // suma total
    }
    
    //Obtener pedidos con detalles de productos
    public async Task<IEnumerable<object>> GetOrdersWithProductDetailsAsync()
    {
        return await _context.OrderDetails
            .Include(od => od.Product)   // datos del producto
            .Include(od => od.Order)     // datos de la orden
            .Select(od => new
            {
                OrderId = od.OrderId,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    
    //Productos vendidos a un cliente 
    public async Task<IEnumerable<object>> GetProductsByClientIdAsync(int clientId)
    {
        return await _context.OrderDetails
            .Include(od => od.Product)
            .Include(od => od.Order)
            .Where(od => od.Order.ClientId == clientId) // filtrar por cliente
            .Select(od => new
            {
                ClientId = od.Order.ClientId,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    
    //Clientes que han comprado un producto específico
    public async Task<IEnumerable<object>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.OrderDetails
            .Include(od => od.Order)
            .ThenInclude(o => o.Client) // incluir cliente desde la orden
            .Where(od => od.ProductId == productId) // filtrar por producto
            .Select(od => new
            {
                ProductId = od.ProductId,
                ClientId = od.Order.ClientId,
                ClientName = od.Order.Client.Name
            })
            .Distinct() // evitar duplicados si el mismo cliente compró varias veces
            .ToListAsync();
    }

}