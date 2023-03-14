using BP_POC.Operations.Shared.Printers;
using BP_POC.Operations.Shared.Sales;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace BP_POC.Operations.Client.Shared;

public class PrinterService : IPrinterService
{
    private readonly HttpClient _client;
    private const string endpoint = "api/printer";

    public PrinterService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<PrinterDto.Index>> GetIndexAsync()
    {
        var response = await _client.GetFromJsonAsync<List<PrinterDto.Index>>(endpoint);
        return response!;
    }

    public async Task<PrinterDto.Detail> GetByIdAsync(int id)
    {
        var response = await _client.GetFromJsonAsync<PrinterDto.Detail>($"{endpoint}/{id}");
        return response!;
    }

    public async Task<List<PrinterDto.Index>> GetByShopIdAsync(int id)
    {
        var response = await _client.GetFromJsonAsync<List<PrinterDto.Index>>($"{endpoint}/{id}");
        return response!;
    }

    public async Task<SaleDto.CalculatedSale> CalculateTotalAmountAsync(PrinterRequest.CalculateTotalAmount request)
    {
        var response = await _client.PostAsJsonAsync($"{endpoint}/CalculateTotalAmount", request);
        return await response.Content.ReadFromJsonAsync<SaleDto.CalculatedSale>();
    }
}
