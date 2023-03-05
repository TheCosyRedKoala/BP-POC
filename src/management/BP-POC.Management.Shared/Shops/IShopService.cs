namespace BP_POC.Management.Shared.Shops;

public interface IShopService
{
    // Shop
    Task<int> CreateAsync(ShopDto.Mutate model);
    Task<List<ShopDto.Index>> GetIndexAsync();
    Task<ShopDto.Detail> GetByIdAsync(int id);

    // Printer
    Task<int> CreatePrinterAsync(ShopRequest.PrinterMutate request);
    Task DeletePrinterAsync(ShopRequest.PrinterDelete request);
}
