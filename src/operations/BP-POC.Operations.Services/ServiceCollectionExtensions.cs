using BP_POC.Operations.Services.Printers;
using BP_POC.Operations.Services.Sales;
using BP_POC.Operations.Shared.Printers;
using BP_POC.Operations.Shared.Sales;
using Microsoft.Extensions.DependencyInjection;

namespace BP_POC.Operations.Services;

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
        services.AddScoped<ISaleService, SaleService>();

        return services;
    }
}
