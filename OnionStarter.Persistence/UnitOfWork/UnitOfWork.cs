using Microsoft.EntityFrameworkCore.Storage;
using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Persistence.Contexts;

namespace OnionStarter.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IProductRepository ProductRepository { get; }

    public UnitOfWork(ApplicationDbContext context, IProductRepository productRepository)
    {
        _context = context;
        ProductRepository = productRepository;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

    public async ValueTask DisposeAsync()
    { }
}