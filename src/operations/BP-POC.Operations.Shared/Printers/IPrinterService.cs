using BP_POC.Operations.Shared.Sales;

namespace BP_POC.Operations.Shared.Printers;

public interface IPrinterService
{
    Task<List<PrinterDto.Index>> GetIndexAsync();
    Task<List<PrinterDto.Index>> GetByShopIdAsync(int id);
    Task<PrinterDto.Detail> GetByIdAsync(int id);
    Task<SaleDto.CalculatedSale> CalculateTotalAmountAsync(PrinterRequest.CalculateTotalAmount request);
}