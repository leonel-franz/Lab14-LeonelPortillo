using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public interface IClientRepository : IGenericRepository<Client>
{
    
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);

    
    Task<ClientePedidosDto?> GetTopClientWithMostOrdersAsync();

    
    Task<IEnumerable<string>> GetClientsByPurchasedProductAsync(int productId);
}