using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _dbContext.Clients
            .Where(c => c.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
    }


    public async Task<ClientePedidosDto?> GetTopClientWithMostOrdersAsync()
    {
        return await _dbContext.Orders
            .GroupBy(o => o.Clientid)
            .OrderByDescending(g => g.Count())
            .Select(g => new ClientePedidosDto
            {
                ClientId = g.Key,
                ClientName = g.First().Client.Name,
                TotalOrders = g.Count()
            })
            .FirstOrDefaultAsync();
    }

    
    public async Task<IEnumerable<string>> GetClientsByPurchasedProductAsync(int productId)
    {
        return await _dbContext.Orderdetails
            .Where(od => od.Productid == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
}