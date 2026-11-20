using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

  public async Task<IEnumerable<Product>> GetProductsPriceGreaterThanAsync(decimal minPrice)
    {
        return await _dbContext.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }

    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _dbContext.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

   
    public async Task<decimal> GetAveragePriceAsync()
    {
        if (!await _dbContext.Products.AnyAsync()) return 0;
        return await _dbContext.Products.AverageAsync(p => p.Price);
    }

    
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _dbContext.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }
}