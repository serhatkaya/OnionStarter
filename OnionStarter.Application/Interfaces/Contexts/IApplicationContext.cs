using Microsoft.EntityFrameworkCore;
using OnionStarter.Domain.Entities;

namespace OnionStarter.Application.Interfaces.Contexts;

public interface IApplicationContext
{
    DbSet<Product> Products { get; set; }
}