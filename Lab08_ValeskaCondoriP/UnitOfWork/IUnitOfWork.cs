using Lab08_ValeskaCondoriP.Repositories.Interfaz;

namespace Lab08_ValeskaCondoriP.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IOrderDetailRepository OrderDetails { get; }
    Task<int> SaveAsync();
}