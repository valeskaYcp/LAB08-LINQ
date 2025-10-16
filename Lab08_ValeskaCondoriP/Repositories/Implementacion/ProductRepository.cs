using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.Repositories.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace Lab08_ValeskaCondoriP.Repositories.Implementacion;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>>
        GetByPriceGreaterThanAsync(decimal price)
    {
        return await _context.Products
            .Where(p => p.Price > price) //LINQ con Where
            .ToListAsync(); //ToListAsync
    }

    //PRODUCTO MAS CARO
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price) // ordenar por precio descendente
            .FirstOrDefaultAsync(); // obtener el primero
    }

    // PROMEDIO DE PRODUCTOS
    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .AverageAsync(p => p.Price);        //calcular promedio
    }

    
    // Productos sin descripción
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description)) // nulos o vacíos
            .ToListAsync();
    }
}
