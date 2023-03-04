using BP_POC.Management.Shared.Printers;
using BP_POC.Management.Shared.Sales;

namespace BP_POC.Management.Shared.Shops;

public interface IShopService
{
    // Shop
    Task CreateAsync();
    Task GetIndexAsync();
    Task GetDetailAsync();

    // Printer
    Task<int> CreatePrinterAsync(PrinterDto.Mutate model);
    Task DeletePrinterAsync(int id);

    // Sale
    Task<int> CreateSaleAsync(SaleDto.Mutate model);
    Task DeleteSaleAsync(int id);

}
