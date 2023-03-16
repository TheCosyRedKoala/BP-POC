using BP_POC.Operations.Shared.Sales;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BP_POC.Operations.Client.Pages.Register.Components;

public partial class SaleOverview
{
    [Inject] ISaleService SaleService { get; set; } = default!;
    [Inject] ISnackbar Snackbar { get; set; } = default!;

    [Parameter, EditorRequired] public double TotalPaymentAmount { get; set; }
    [Parameter, EditorRequired] public List<SaleDto.CalculatedSale> Sales { get; set; }
    [Parameter, EditorRequired] public EventCallback ClearSalesOverviewScreen { get; set; }

    private async Task HandleRegisterPaymentClick()
    {
        SaleDto.Mutate model = new()
        {
            TotalAmount = TotalPaymentAmount
        };

        SaleRequest.Mutate saleRequest = new()
        {
            ShopId = 1,
            Sale = model
        };

        await SaleService.CreateAsync(saleRequest);

        await ClearSalesOverviewScreen.InvokeAsync();

        Snackbar.Add("Sale successfully registrated", Severity.Success);
    }

    private async Task HandleRegisterEndOfDayClick()
    {
        bool success = await SaleService.RegisterEndOfDay(1);

        if (success)
        {
            Snackbar.Add("Register successfully closed", Severity.Success);
        }
    }
}