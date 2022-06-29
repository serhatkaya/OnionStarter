using Microsoft.EntityFrameworkCore;
using OnionStarter.Domain.Entities;

namespace OnionStarter.Application.Interfaces.Contexts;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}