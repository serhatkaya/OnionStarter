using OnionStarter.Domain.Common;

namespace OnionStarter.Application.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    Task<List<T>> GetAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
}