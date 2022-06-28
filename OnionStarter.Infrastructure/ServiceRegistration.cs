using Microsoft.Extensions.DependencyInjection;
using OnionStarter.Application.Interfaces.Services;
using OnionStarter.Infrastructure.Services;

namespace OnionStarter.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEmailService, EmailService>();
    }
}