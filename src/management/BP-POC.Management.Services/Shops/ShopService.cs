using BP_POC.Domain.Exceptions;
using BP_POC.Domain.Printers;
using BP_POC.Domain.Shops;
using BP_POC.Management.Shared.Printers;
using BP_POC.Management.Shared.Sales;
using BP_POC.Management.Shared.Shops;
using BP_POC.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BP_POC.Management.Services.Shops;

public class ShopService : IShopService
{
    private readonly ApplicationDbContext _context;

    public ShopService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(ShopDto.Mutate model)
    {
        Address address = new(model.Address.AddressLine1, model.Address.AddressLine2, model.Address.City, model.Address.PostalCode, model.Address.Country);
        Shop shop = new(model.Name, address);

        _context.Shops.Add(shop);
        await _context.SaveChangesAsync();

        return shop.Id;
    }

    public async Task<List<ShopDto.Index>> GetIndexAsync()
    {
        return await _context.Shops
            .Select(s => new ShopDto.Index
            {
                Id = s.Id,
                Name = s.Name,
            })
            .ToListAsync();
    }

    public async Task<ShopDto.Detail> GetByIdAsync(int id)
    {
        Shop? shop = await _context.Shops
            .Include(s => s.Printers)
            .Include(s => s.Sales)
            .FirstOrDefaultAsync(s => id == s.Id);

        if (shop is null)
        {
            throw new EntityNotFoundException(nameof(Shop), id);
        }

        return new ShopDto.Detail
        {
            Id = id,
            Name = shop.Name,
            Address = new AddressDto.Index
            {
                AddressLine1 = shop.Address.AddressLine1,
                AddressLine2 = shop.Address.AddressLine2,
                City = shop.Address.City,
                PostalCode = shop.Address.PostalCode,
                Country = shop.Address.Country
            },
            Printers = shop.Printers.Select(p => new PrinterDto.Index
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList(),
            Sales = shop.Sales.Select(s => new SaleDto.Index
            {
                Id = s.Id,
                DateOfSale = s.DateOfSale,
                TotalAmount = s.TotalAmount,
            }).ToList()
        };
    }

    public async Task<int> CreatePrinterAsync(ShopRequest.PrinterMutate request)
    {
        Shop? shop = await _context.Shops
            .Include(s => s.Printers)
            .FirstOrDefaultAsync(s => request.ShopId == s.Id);

        if (shop is null)
        {
            throw new EntityNotFoundException(nameof(Shop), request.ShopId);
        }

        Printer printer = new(request.Printer.Name, request.Printer.ListeningInterface);

        shop.AddPrinter(printer);

        await _context.SaveChangesAsync();

        return printer.Id;
    }

    public async Task DeletePrinterAsync(ShopRequest.PrinterDelete request)
    {
        Shop? shop = await _context.Shops
            .Include(s => s.Printers)
            .FirstOrDefaultAsync(s => request.ShopId == s.Id);

        if (shop is null)
        {
            throw new EntityNotFoundException(nameof(Shop), request.ShopId);
        }

        Printer? printer = _context.Printers.FirstOrDefault(s => request.PrinterId == s.Id);

        if (printer is null)
        {
            throw new EntityNotFoundException(nameof(Printer), request.PrinterId);
        }

        shop.RemovePrinter(printer);

        await _context.SaveChangesAsync();
    }
}
