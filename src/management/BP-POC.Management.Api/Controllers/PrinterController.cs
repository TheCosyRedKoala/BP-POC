using BP_POC.Management.Shared.Printers;
using Microsoft.AspNetCore.Mvc;

namespace BP_POC.Management.Api.Controllers;

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

	[HttpGet("{id}")]
	public async Task<PrinterDto.Detail> GetDetailAsync(int id)
	{
		return await _printerService.GetByIdAsync(id);
	}

	[HttpPost("AddPriceTier")]
	public async Task<int> CreatePriceTierAsync(PrinterRequest.PriceTierMutate request)
	{
		return await _printerService.CreatePriceTierAsync(request);
	}
}
