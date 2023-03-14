using BP_POC.Domain.Exceptions;
using BP_POC.Domain.Printers;
using BP_POC.Domain.Sales;
using BP_POC.Domain.Shops;
using BP_POC.Operations.Shared.Printers;
using BP_POC.Operations.Shared.Sales;
using BP_POC.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BP_POC.Operations.Services.Sales;

public class SaleService : ISaleService
{
    private readonly ApplicationDbContext _context;

    public SaleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(SaleRequest.Mutate request)
    {
        Shop? shop = await _context.Shops
            .FirstOrDefaultAsync(s => request.ShopId == s.Id);

        if (shop is null)
        {
            throw new EntityNotFoundException(nameof(Shop), request.ShopId);
        }

        Sale sale = new(request.Sale.TotalAmount);

        shop.AddSale(sale);

        await _context.SaveChangesAsync();

        return sale.Id;
    }

    public async Task<List<SaleDto.Index>> GetIndexAsync()
    {
        return await _context.Sales
            .Select(s => new SaleDto.Index
            {
                Id = s.Id,
                DateOfSale= s.DateOfSale,
                TotalAmount = s.TotalAmount
            })
            .ToListAsync();
    }

    public async Task<SaleDto.Detail> GetByIdAsync(int id)
    {
        Sale? sale = await _context.Sales
            .FirstOrDefaultAsync(s => id == s.Id);

        if (sale is null)
        {
            throw new EntityNotFoundException(nameof(Sale), id);
        }

        return new SaleDto.Detail
        {
            Id = sale.Id,
            DateOfSale = sale.DateOfSale,
            TotalAmount = sale.TotalAmount
        };
    }
}
