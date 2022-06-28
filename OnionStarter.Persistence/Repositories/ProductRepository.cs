using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Domain.Entities;
using OnionStarter.Persistence.Contexts;

namespace OnionStarter.Persistence.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    { }
}