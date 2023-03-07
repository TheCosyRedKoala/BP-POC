namespace BP_POC.Operations.Shared.Sales;

public interface ISaleService
{
    Task<int> CreateAsync(SaleRequest.Mutate request);
    Task<List<SaleDto.Index>> GetIndexAsync();
    Task<SaleDto.Detail> GetByIdAsync(int id);
}
