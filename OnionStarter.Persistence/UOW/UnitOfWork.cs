using Microsoft.EntityFrameworkCore.Storage;
using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Persistence.Contexts;

namespace OnionStarter.Persistence.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IProductRepository ProductRepository { get; }

    public UnitOfWork(ApplicationDbContext dbContext, IProductRepository productRepository)
    {
        _dbContext = dbContext;
        ProductRepository = productRepository;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync() => await _dbContext.Database.BeginTransactionAsync();

    public async ValueTask DisposeAsync()
    { }
}