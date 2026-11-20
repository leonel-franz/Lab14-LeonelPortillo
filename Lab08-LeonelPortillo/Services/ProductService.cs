using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.DTOs;
using Lab08_LeonelPortillo.Models;
using Lab08_LeonelPortillo.Repository;

namespace Lab08_LeonelPortillo.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Product>> GetProductsPriceGreaterThanAsync(decimal minPrice)
    {
        return await _unitOfWork.Products.GetProductsPriceGreaterThanAsync(minPrice);
    }

    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _unitOfWork.Products.GetMostExpensiveProductAsync();
    }

    
    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _unitOfWork.Products.GetAveragePriceAsync();
    }

   
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _unitOfWork.Products.GetProductsWithoutDescriptionAsync();
    }
}