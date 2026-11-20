using Lab08_LeonelPortillo;
using Microsoft.EntityFrameworkCore;
using Lab08_LeonelPortillo.Models;

namespace Lab08_LeonelPortillo.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T:class
{
    protected readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }
}