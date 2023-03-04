namespace BP_POC.Management.Shared.Printers;

public interface IPrinterService
{
    // Printer
    Task<List<PrinterDto.Index>> GetIndexAsync();
    Task<PrinterDto.Detail> GetByIdAsync(int id);

    // PriceTier
    Task CreatePriceTierAsync(PriceTierDto.Mutate model);
}
