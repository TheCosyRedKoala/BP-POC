namespace BP_POC.Reporting.Shared.Reports;

public interface IReportService
{
    Task<int> CreateAsync(ReportDto.Mutate model);
    Task<List<ReportDto.Index>> GetIndexAsync();
    Task<List<ReportDto.Index>> GetByDayAsync(DateTime date);
    Task<List<ReportDto.Index>> GetToday();
    Task<List<ReportDto.Index>> GetByShop(int shopId);
}
