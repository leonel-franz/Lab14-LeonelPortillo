using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<DetalleProductoDto>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await _dbContext.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => new DetalleProductoDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }

    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        return await _dbContext.Orderdetails
            .Where(od => od.Orderid == orderId)
            .SumAsync(od => od.Quantity);
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _dbContext.Orders
            .Where(o => o.Orderdate > date)
            .ToListAsync();
    }

    public async Task<IEnumerable<PedidoConDetallesDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _dbContext.Orders
            .Select(o => new PedidoConDetallesDto
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate,
                Detalles = o.Orderdetails.Select(od => new DetalleProductoDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetProductsSoldToClientAsync(int clientId)
    {
        return await _dbContext.Orders
            .Where(o => o.Clientid == clientId)
            .SelectMany(o => o.Orderdetails)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
}