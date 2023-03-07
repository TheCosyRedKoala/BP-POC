using BP_POC.Operations.Shared.Printers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BP_POC.Operations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController : ControllerBase
{
    private readonly IPrinterService _printerService;

	public PrinterController(IPrinterService printerService)
	{
		_printerService = printerService;
	}

    [HttpGet]
    public async Task<List<PrinterDto.Index>> GetIndexAsync()
    {
        return await _printerService.GetIndexAsync();
    }

    [HttpGet("Shop/{id}")]
    public async Task<List<PrinterDto.Index>> GetByShopIdAsync(int id)
    {
        return await _printerService.GetByShopIdAsync(id);
    }

    [HttpGet("{id}")]
    public async Task<PrinterDto.Detail> GetDetailAsync(int id)
    {
        return await _printerService.GetByIdAsync(id);
    }
}
