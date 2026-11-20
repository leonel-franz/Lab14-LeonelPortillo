using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Services;

public interface IClientService
{
    
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);

    
    Task<ClientePedidosDto?> GetTopClientWithMostOrdersAsync();

    
    Task<IEnumerable<string>> GetClientsByPurchasedProductAsync(int productId);
}