using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Persistence.Contexts;
using OnionStarter.Persistence.Repositories;

namespace OnionStarter.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection serviceCollection,
        IConfiguration configuration = null)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration?.GetConnectionString("SQLConnection")));

        serviceCollection.AddTransient<IProductRepository, ProductRepository>();
        serviceCollection.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}