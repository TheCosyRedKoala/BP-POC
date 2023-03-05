using BP_POC.Domain.Exceptions;
using BP_POC.Domain.Printers;
using BP_POC.Management.Shared.Printers;
using BP_POC.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BP_POC.Management.Services.Printers;

public class PrinterService : IPrinterService
{
    private readonly ApplicationDbContext _context;

    public PrinterService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PrinterDto.Index>> GetIndexAsync()
    {
        return await _context.Printers
            .Select(p => new PrinterDto.Index
            {
                Id = p.Id,
                Name = p.Name,
            })
            .ToListAsync();
    }

    public async Task<PrinterDto.Detail> GetByIdAsync(int id)
    {
        Printer? printer = await _context.Printers
            .Include(p => p.PriceTiers)
            .FirstOrDefaultAsync(p => id == p.Id);

        if (printer is null)
        {
            throw new EntityNotFoundException(nameof(Printer), id);
        }

        return new PrinterDto.Detail
        {
            Id = printer.Id,
            Name = printer.Name,
            ListeningInterface = printer.ListeningInterface,
            PriceTiers = printer.PriceTiers
                .Select(pt => new PriceTierDto.Index
                {
                    Floor = pt.Floor,
                    Ceiling = pt.Ceiling,
                    Price = pt.Price
                })
                .ToList()
        };
    }

    public async Task<int> CreatePriceTierAsync(PrinterRequest.PriceTierMutate request)
    {
        Printer? printer = _context.Printers.FirstOrDefault(p => request.PrinterId == p.Id);

        if (printer is null) 
        {
            throw new EntityNotFoundException(nameof(Printer), request.PrinterId);
        }

        PriceTier priceTier = new(request.PriceTier.Floor, request.PriceTier.Ceiling, request.PriceTier.Price);

        printer.AddPriceTier(priceTier);

        await _context.SaveChangesAsync();

        return priceTier.Id;
    }
}
