using BP_POC.Domain.Reports;
using BP_POC.Persistence;
using BP_POC.Reporting.Shared.Reports;
using Microsoft.EntityFrameworkCore;

namespace BP_POC.Reporting.Services.Reports;

public class ReportService : IReportService
{
    private readonly ApplicationDbContext _context;

    public ReportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(ReportDto.Mutate model)
    {
        Report report = new(model.DayOfSale, model.TotalRevenue, model.ShopId);

        _context.Reports.Add(report);
        await _context.SaveChangesAsync();

        return report.Id;
    }

    public async Task<List<ReportDto.Index>> GetIndexAsync()
    {
        return await _context.Reports
            .Select(r => new ReportDto.Index
            {
                Id = r.Id,
                DayOfSale = r.DayOfSale,
                TotalRevenue = r.TotalRevenue,
                ShopId = r.ShopId
            })
            .ToListAsync();
    }

    public async Task<List<ReportDto.Index>> GetByDayAsync(DateTime date)
    {
        return await _context.Reports
            .Where(r => date.Date == r.DayOfSale.Date)
            .Select(r => new ReportDto.Index
            {
                Id = r.Id,
                DayOfSale = r.DayOfSale,
                TotalRevenue = r.TotalRevenue,
                ShopId = r.ShopId
            })
            .ToListAsync();
    }

    public async Task<List<ReportDto.Index>> GetToday()
    {
        return await GetByDayAsync(DateTime.UtcNow);
    }

    public async Task<List<ReportDto.Index>> GetByShop(int shopId)
    {
        return await _context.Reports
            .Where(r => shopId == r.ShopId)
            .Select(r => new ReportDto.Index
            {
                Id = r.Id,
                DayOfSale = r.DayOfSale,
                TotalRevenue = r.TotalRevenue,
                ShopId = r.ShopId
            })
            .ToListAsync();
    }
}
