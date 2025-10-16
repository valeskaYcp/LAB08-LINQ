using Lab08_ValeskaCondoriP.Models;

namespace Lab08_ValeskaCondoriP.Repositories.Interfaz;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price);
    Task<Product?> GetMostExpensiveProductAsync(); //producto mas caro
    Task<decimal> GetAveragePriceAsync(); //promedio de productos
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync(); //Productos que No Tienen Descripción
    
}