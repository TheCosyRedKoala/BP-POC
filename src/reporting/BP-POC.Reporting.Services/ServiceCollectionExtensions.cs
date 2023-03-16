using BP_POC.Reporting.Shared.Reports;
using BP_POC.Reporting.Services.Reports;
using Microsoft.Extensions.DependencyInjection;

namespace BP_POC.Reporting.Services;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all services to the DI container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
        services.AddScoped<IReportService, ReportService>();

        return services;
    }
}
