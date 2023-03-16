using BP_POC.Operations.Shared.Sales;
using System.Net.Http.Json;

namespace BP_POC.Operations.Client.Shared;

public class SaleService : ISaleService
{
    private readonly HttpClient _client;
    private readonly HttpClient _managementClient;
    private const string endpoint = "api/sale";
    private const string managementEndpoint = "api/shop";

    public SaleService(HttpClient client, IHttpClientFactory clientFactory)
    {
        _client = client;
        _managementClient = clientFactory.CreateClient("BP-POC.ManagementApi");
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

    public async Task<bool> RegisterEndOfDay(int shopId)
    {
        var response = await _managementClient.GetFromJsonAsync<bool>($"{managementEndpoint}/{shopId}/endofday");
        return response;
    }
}
