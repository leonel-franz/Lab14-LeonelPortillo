using System;
using System.Threading.Tasks;

namespace Lab08_LeonelPortillo.Repository;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    Task<int> CompleteAsync();
}