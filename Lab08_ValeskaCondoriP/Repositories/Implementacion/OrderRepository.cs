using Lab08_ValeskaCondoriP.DTOs;
using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.Repositories.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ValeskaCondoriP.Repositories.Implementacion;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)   // filtrar por fecha
            .ToListAsync();                   // devolver lista
    }
    
    // Cliente con más pedidos
    public async Task<object?> GetClientWithMostOrdersAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.ClientId)                            // agrupar por cliente
            .Select(g => new { ClientId = g.Key, Count = g.Count() }) // proyectar id y total
            .OrderByDescending(x => x.Count)                     // Ordenar por cantidad
            .FirstOrDefaultAsync();                             
    }
    
    // Consulta con Include y ThenInclude
    public IEnumerable<OrderDetailsDto> GetOrdersWithDetails()
    {
        return _context.Orders
            .Include(order => order.OrderDetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking() // mejora rendimiento
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Products = order.OrderDetails.Select(od => new ProductDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity,
                    Price = od.Product.Price
                }).ToList()
            })
            .ToList();
    }
}