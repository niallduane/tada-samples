using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Database;

public static class DependencyRegistration
{
    public static DbContextOptionsBuilder Configure(this DbContextOptionsBuilder options, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Database")!;
        options.UseNpgsql(connectionString);
        return options;
    }

    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DatabaseContext>((serviceProvider, options) => options.Configure(config));
    }
}