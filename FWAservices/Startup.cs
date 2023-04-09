using Microsoft.Extensions.DependencyInjection;

namespace FWAservices;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        FWAdata.Startup.ConfigureServices(services);

        services.AddScoped<UserService>();
    }
}