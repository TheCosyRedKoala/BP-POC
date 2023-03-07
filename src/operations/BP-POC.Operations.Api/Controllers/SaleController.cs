using BP_POC.Operations.Shared.Sales;
using Microsoft.AspNetCore.Mvc;

namespace BP_POC.Operations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService printerService)
    {
        _saleService = printerService;
    }

    [HttpPost]
    public async Task<int> CreateAsync([FromBody] SaleRequest.Mutate request)
    {
        return await _saleService.CreateAsync(request);
    }

    [HttpGet]
    public async Task<List<SaleDto.Index>> GetIndexAsync()
    {
        return await _saleService.GetIndexAsync();
    }

    [HttpGet("{id}")]
    public async Task<SaleDto.Detail> GetByIdAsync(int id)
    {
        return await _saleService.GetByIdAsync(id);
    }
}
