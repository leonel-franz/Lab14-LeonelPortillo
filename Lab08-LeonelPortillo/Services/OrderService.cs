using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;
using Lab08_LeonelPortillo.Repository;

namespace Lab08_LeonelPortillo.Services;
public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    
    public async Task<IEnumerable<DetalleProductoDto>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.Orders.GetOrderDetailsByOrderIdAsync(orderId);
    }

    
    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.Orders.GetTotalProductQuantityByOrderIdAsync(orderId);
    }

    
    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _unitOfWork.Orders.GetOrdersAfterDateAsync(date);
    }

  
    public async Task<IEnumerable<PedidoConDetallesDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _unitOfWork.Orders.GetAllOrdersWithDetailsAsync();
    }

    
    public async Task<IEnumerable<string>> GetProductsSoldToClientAsync(int clientId)
    {
        return await _unitOfWork.Orders.GetProductsSoldToClientAsync(clientId);
    }
}