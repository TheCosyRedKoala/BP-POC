namespace BP_POC.Operations.Shared.Printers;

public interface IPrinterService
{
    Task<List<PrinterDto.Index>> GetIndexAsync();
    Task<List<PrinterDto.Index>> GetByShopIdAsync(int id);
    Task<PrinterDto.Detail> GetByIdAsync(int id);
}
