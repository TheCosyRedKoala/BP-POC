using BP_POC.Operations.Shared.Sales;
using System.Net.Http.Json;

namespace BP_POC.Operations.Client.Shared;

public class SaleService : ISaleService
{
    private readonly HttpClient _client;
    private const string endpoint = "api/sale";

    public SaleService(HttpClient client)
    {
        _client = client;
    }

    public async Task<int> CreateAsync(SaleRequest.Mutate request)
    {
        var response = await _client.PostAsJsonAsync(endpoint, request);
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public Task<SaleDto.Detail> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SaleDto.Index>> GetIndexAsync()
    {
        throw new NotImplementedException();
    }
}
