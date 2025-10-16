using Lab08_ValeskaCondoriP.DTOs;
using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.Repositories.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ValeskaCondoriP.Repositories.Implementacion;

public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Client>> GetByNameAsync(string name)
        {
            return await _dbSet
                .Where(c => c.Name.StartsWith(name))
                .ToListAsync();
        }
        
        //consulta con AsNoTracking
        public IEnumerable<ClientOrderDto> GetClientsWithOrders()
        {
            return _context.Clients
                .AsNoTracking() // mejora rendimiento para solo lectura
                .Select(client => new ClientOrderDto
                {
                    ClientName = client.Name,
                    Orders = client.Orders
                        .Select(order => new OrderDto
                        {
                            OrderId = order.OrderId,
                            OrderDate = order.OrderDate
                        }).ToList()
                }).ToList();
        }

        
        //Doble Consulta a la Base de Datos
        public IEnumerable<object> GetClientsWithProductCount()
        {
            return _context.Clients
                .AsNoTracking()
                .Select(client => new
                {
                    ClientName = client.Name,
                    TotalProducts = client.Orders
                        .Sum(order => order.OrderDetails
                            .Sum(detail => detail.Quantity))
                })
                .ToList();
        }
        
        //Consulta Avanzada con Filtros y Agrupación
        public IEnumerable<SalesByClientDto> GetSalesByClient()
        {
            return _context.Orders
                .Include(order => order.OrderDetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .AsNoTracking()
                .GroupBy(order => order.ClientId)
                .Select(group => new SalesByClientDto
                {
                    ClientName = _context.Clients
                        .FirstOrDefault(c => c.ClientId == group.Key).Name,
                    TotalSales = group.Sum(order => order.OrderDetails
                        .Sum(detail => detail.Quantity * detail.Product.Price))
                })
                .OrderByDescending(s => s.TotalSales)
                .ToList();
        }
    }
    