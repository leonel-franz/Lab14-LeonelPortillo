using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public interface IOrderRepository : IGenericRepository<Order>
{
    
    Task<IEnumerable<DetalleProductoDto>> GetOrderDetailsByOrderIdAsync(int orderId);

    
    Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId);

    
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);

    
    Task<IEnumerable<PedidoConDetallesDto>> GetAllOrdersWithDetailsAsync();

    
    Task<IEnumerable<string>> GetProductsSoldToClientAsync(int clientId);
}