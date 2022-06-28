using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnionStarter.Persistence.Contexts;

public abstract class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    public TContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<TContext> builder = new DbContextOptionsBuilder<TContext>();
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OnionStarter.WebAPI"))
            .AddJsonFile("appsettings.json")
            .Build();
        builder.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
        return CreateNewInstance(builder.Options);
    }
}