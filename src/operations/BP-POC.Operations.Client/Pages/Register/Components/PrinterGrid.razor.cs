using BP_POC.Operations.Shared.Printers;
using Microsoft.AspNetCore.Components;

namespace BP_POC.Operations.Client.Pages.Register.Components;

public partial class PrinterGrid
{
    [Parameter, EditorRequired] public List<PrinterDto.Index> Printers { get; set; }
    [Parameter, EditorRequired] public EventCallback<CalculateTotalAmountParams> CalculateTotalAmount { get; set; }

    private async Task HandleCalculateTotalAmountClick(int printerId, int amountPrinted)
    {
        CalculateTotalAmountParams parameters = new()
        {
            PrinterId = printerId,
            AmountPrinted = amountPrinted
        };

        await CalculateTotalAmount.InvokeAsync(parameters);
    }
}