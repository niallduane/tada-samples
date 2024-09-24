using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Database.Repositories;
public static class DependencyRegistration
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration config)
    {
        // <!-- tada injection token -->
    }
}