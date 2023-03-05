using BP_POC.Management.Services.Printers;
using BP_POC.Management.Services.Shops;
using BP_POC.Management.Shared.Printers;
using BP_POC.Management.Shared.Shops;
using Microsoft.Extensions.DependencyInjection;

namespace BP_POC.Management.Services;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all services to the DI container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddScoped<IPrinterService, PrinterService>();
        services.AddScoped<IShopService, ShopService>();

        return services;
    }
}
