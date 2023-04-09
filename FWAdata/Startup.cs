using FWAdata.Business;
using FWAdata.DbAccess;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FWAdata;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Register Business classes
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(o => o.BaseType == typeof(Business.Business));
        foreach (Type type in types)
        {
            services.AddScoped(type);
        }

        services.AddScoped<DbContextFactory>();

        services.AddScoped<IBusinessProvider>(serviceProvider =>
        {
            Business.Business BusinessFactory(Type type)
            {
                Business.Business b = (Business.Business)serviceProvider.GetService(type);
                b.SetDbContextFactory(serviceProvider.GetService<DbContextFactory>());
                return b;
            }

            return new BusinessProvider(BusinessFactory);
        });
    }
}