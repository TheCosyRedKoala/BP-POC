using BP_POC.Operations.Api.Hubs;
using BP_POC.Operations.Shared.Printers;
using BP_POC.Operations.Shared.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BP_POC.Operations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController : ControllerBase
{
    private readonly IPrinterService _printerService;
    private readonly IHubContext<PrinterHub> _printerHub;

	public PrinterController(IPrinterService printerService, IHubContext<PrinterHub> printerHub)
	{
		_printerService = printerService;
        _printerHub = printerHub;
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

    [HttpPatch("{id}")]
    public async Task<IActionResult> RegisterPrinterClickAsync(int id)
    {
        await _printerHub.Clients.All.SendAsync("ReceivePrintClick", id);
        return Ok();
    }

    [HttpPost("CalculateTotalAmount")]
    public async Task<SaleDto.CalculatedSale> CalculateTotalAmountAsync([FromBody] PrinterRequest.CalculateTotalAmount request)
    {
        return await _printerService.CalculateTotalAmountAsync(request);
    }
}