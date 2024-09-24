using Demo.Presentation.Api.Middleware;

namespace Demo.Presentation.Api.Startup;

public static class WebApplicationRegistration
{
    public static void RegisterMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ResponseTimer>();
    }
}