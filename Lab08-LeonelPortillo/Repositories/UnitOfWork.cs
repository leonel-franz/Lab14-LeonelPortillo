using System.Threading.Tasks;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IClientRepository Clients { get; }
    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IClientRepository clientRepository,
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _context = context;
        Clients = clientRepository;
        Products = productRepository;
        Orders = orderRepository;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}