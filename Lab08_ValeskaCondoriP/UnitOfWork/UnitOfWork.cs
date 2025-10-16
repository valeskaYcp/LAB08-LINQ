using Lab08_ValeskaCondoriP.Models;
using Lab08_ValeskaCondoriP.Repositories.Interfaz;

namespace Lab08_ValeskaCondoriP.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IClientRepository Clients { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public IOrderDetailRepository OrderDetails { get; }

        public UnitOfWork(AppDbContext context,
            IClientRepository clients,
            IProductRepository products,
            IOrderRepository orders,
            IOrderDetailRepository orderDetails)
        {
            _context = context;
            Clients = clients;
            Products = products;
            Orders = orders;
            OrderDetails = orderDetails;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}