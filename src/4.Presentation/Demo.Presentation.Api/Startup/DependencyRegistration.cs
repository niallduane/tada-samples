using Demo.Infrastructure.Database;
using Demo.Infrastructure.Database.Repositories;
using Demo.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Demo.Presentation.Api.Startup;

public static class DependencyRegistration
{
    public static void Register(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors();

        services.AddHttpContextAccessor();

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(2, 0);
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        services.AddVersionedApiExplorer(o =>
        {
            o.GroupNameFormat = "'v'VVV";
            o.SubstituteApiVersionInUrl = true;
        });

        services.RegisterInfrastructure(config);
        services.RegisterServices(config);
    }

    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureDatabase(config);
        services.RegisterRepositories(config);
        // <!-- tada infrastructure injection token -->
    }
}