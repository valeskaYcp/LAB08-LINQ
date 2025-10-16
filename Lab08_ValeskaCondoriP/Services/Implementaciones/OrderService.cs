using Lab08_ValeskaCondoriP.DTOs;
using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ValeskaCondoriP.Services.Implementaciones;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    // Consulta con Include y ThenInclude
    public IEnumerable<OrderDetailsDto> GetOrdersWithDetails()
    {
        return _context.Orders
            .Include(order => order.OrderDetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking()
            .Select(order => new OrderDetailsDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Products = order.OrderDetails
                    .Select(od => new ProductDto
                    {
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        Price = od.Product.Price
                    })
                    .ToList()
            })
            .ToList();
    }
}
