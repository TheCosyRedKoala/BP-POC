using BP_POC.Reporting.Shared.Reports;
using Microsoft.AspNetCore.Mvc;

namespace BP_POC.Reporting.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost]
    public async Task<int> CreateAsync([FromBody] ReportDto.Mutate model)
    {
        return await _reportService.CreateAsync(model);
    }

    [HttpGet]
    public async Task<List<ReportDto.Index>> GetIndexAsync()
    {
        return await _reportService.GetIndexAsync();
    }

    [HttpGet("{shopId}")]
    public async Task<List<ReportDto.Index>> GetByShop(int shopId)
    {
        return await _reportService.GetByShop(shopId);
    }

    [HttpGet("today")]
    public async Task<List<ReportDto.Index>> GetToday()
    {
        return await _reportService.GetToday();
    }
}
