using BP_POC.Operations.Shared.Sales;
using BP_POC.Operations.Shared.Printers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BP_POC.Operations.Client.Pages.Register;

public partial class Index
{
    [Inject] public IPrinterService PrinterService { get; set; } = default!;

    private List<PrinterDto.Index> _printers;
    private List<SaleDto.CalculatedSale> _sales = new();

    private HubConnection _hubConnection;
    private double _totalPaymentAmount;

    protected override async Task OnInitializedAsync()
    {
        _printers = await GetPrinters();

        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7057/printerhub")
            .Build();

        _hubConnection.On<int>("ReceivePrintClick", printerId =>
        {
            PrinterDto.Index printer = _printers.First(p => printerId == p.Id);
            printer.AmountPrinted++;
            StateHasChanged();
        });

        await _hubConnection.StartAsync();
    }

    private async Task<List<PrinterDto.Index>> GetPrinters()
    {
        return await PrinterService.GetIndexAsync();
    }

    private async Task CalculateTotalAmount(CalculateTotalAmountParams parameters)
    {
        if (parameters.AmountPrinted > 0)
        {
            PrinterRequest.CalculateTotalAmount request = new()
            {
                PrinterId = parameters.PrinterId,
                AmountPrinted = parameters.AmountPrinted
            };

            SaleDto.CalculatedSale sale = await PrinterService.CalculateTotalAmountAsync(request);

            _printers.First(p => parameters.PrinterId == p.Id).AmountPrinted = 0;

            _totalPaymentAmount += sale.TotalAmount;

            _sales.Add(sale);
        }
    }

    private void ClearSalesOverviewScreen()
    {
        _sales = new();
        _totalPaymentAmount = 0;
    }
}