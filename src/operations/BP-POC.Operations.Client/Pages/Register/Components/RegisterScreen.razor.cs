using BP_POC.Operations.Shared.Sales;
using BP_POC.Operations.Shared.Printers;
using Microsoft.AspNetCore.Components;

namespace BP_POC.Operations.Client.Pages.Register.Components;

public partial class RegisterScreen
{
    [Parameter, EditorRequired] public double TotalPaymentAmount { get; set; }
    [Parameter, EditorRequired] public List<PrinterDto.Index> Printers { get; set; }
    [Parameter, EditorRequired] public List<SaleDto.CalculatedSale> Sales { get; set; }
    [Parameter, EditorRequired] public EventCallback<CalculateTotalAmountParams> CalculateTotalAmount { get; set; }
    [Parameter, EditorRequired] public EventCallback ClearSalesOverviewScreen { get; set; }
}