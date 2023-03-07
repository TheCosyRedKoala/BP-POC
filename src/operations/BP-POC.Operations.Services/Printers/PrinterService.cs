using BP_POC.Domain.Exceptions;
using BP_POC.Domain.Printers;
using BP_POC.Domain.Shops;
using BP_POC.Operations.Shared.Printers;
using BP_POC.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BP_POC.Operations.Services.Printers;

public class PrinterService : IPrinterService
{
    private readonly ApplicationDbContext _context;

    public PrinterService(ApplicationDbContext printerService)
    {
        _context = printerService;
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

    public async Task<List<PrinterDto.Index>> GetByShopIdAsync(int id)
    {
        Shop? shop = await _context.Shops
            .Include(s => s.Printers)
            .FirstOrDefaultAsync(s => id == s.Id);

        if (shop is null)
        {
            throw new EntityNotFoundException(nameof(Shop), id);
        }

        return shop.Printers
            .Select(p => new PrinterDto.Index
            {
                Id = p.Id,
                Name = p.Name,
            })
            .ToList();
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
}
