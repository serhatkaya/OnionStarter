using Microsoft.EntityFrameworkCore.Storage;

namespace OnionStarter.Application.Interfaces.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    public IProductRepository ProductRepository { get; }
}