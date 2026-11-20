using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Services;

public interface IProductService
{


    Task<IEnumerable<Product>> GetProductsPriceGreaterThanAsync(decimal minPrice);


    Task<Product?> GetMostExpensiveProductAsync();

    
    Task<decimal> GetAveragePriceAsync();

   
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
}