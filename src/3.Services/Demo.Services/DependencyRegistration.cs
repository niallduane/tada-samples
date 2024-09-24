using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Services;

public static class DependencyRegistration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration config)
    {
        // <!-- tada injection token -->
    }
}