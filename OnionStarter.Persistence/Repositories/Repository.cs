using Microsoft.EntityFrameworkCore;
using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Domain.Common;
using OnionStarter.Persistence.Contexts;

namespace OnionStarter.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table
    {
        get => _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> GetAsync() => await Table.ToListAsync();
    public async Task<T> GetByIdAsync(Guid id) => await Table.FindAsync(id);
}