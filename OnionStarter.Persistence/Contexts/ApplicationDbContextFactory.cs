using Microsoft.EntityFrameworkCore;

namespace OnionStarter.Persistence.Contexts;

public class ApplicationDbContextFactory : DesignTimeDbContextFactory<ApplicationDbContext>
{
    protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
    {
        return new ApplicationDbContext(options);
    }
}