using Microsoft.EntityFrameworkCore;
using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Domain.Common;
using OnionStarter.Persistence.Contexts;

namespace OnionStarter.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private DbSet<T> Table
    {
        get => _dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> GetAsync() => await Table.ToListAsync();
    public async Task<T> GetByIdAsync(Guid id) => await Table.FindAsync(id);
}