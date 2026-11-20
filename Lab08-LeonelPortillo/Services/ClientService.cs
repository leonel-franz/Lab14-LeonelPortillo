using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;
using Lab08_LeonelPortillo.Repository;

namespace Lab08_LeonelPortillo.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _unitOfWork.Clients.GetClientsByNameAsync(name);
    }

    public async Task<ClientePedidosDto?> GetTopClientWithMostOrdersAsync()
    {
        return await _unitOfWork.Clients.GetTopClientWithMostOrdersAsync();
    }

    public async Task<IEnumerable<string>> GetClientsByPurchasedProductAsync(int productId)
    {
        return await _unitOfWork.Clients.GetClientsByPurchasedProductAsync(productId);
    }
}