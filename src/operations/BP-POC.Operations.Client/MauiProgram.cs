using Append.Blazor.Sidepanel;
using BP_POC.Operations.Client.Shared;
using BP_POC.Operations.Shared.Printers;
using BP_POC.Operations.Shared.Sales;
using MudBlazor;
using MudBlazor.Services;

namespace BP_POC.Operations.Client;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services
            .AddHttpClient("BP-POC.OperationsApi", client => client.BaseAddress = new Uri("https://localhost:7057"));

        builder.Services
            .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            .CreateClient("BP-POC.OperationsApi"));

        builder.Services
            .AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
            });

        builder.Services
            .AddScoped<IPrinterService, PrinterService>();

        builder.Services
            .AddScoped<ISaleService, SaleService>();

        builder.Services
            .AddSidepanel();

        builder.Services
            .AddMauiBlazorWebView();
#if DEBUG
		builder.Services
            .AddBlazorWebViewDeveloperTools();
#endif

        return builder.Build();
    }
}