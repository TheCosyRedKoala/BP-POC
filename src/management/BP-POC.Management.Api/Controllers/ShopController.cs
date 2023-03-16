using BP_POC.Management.Shared.Shops;
using Microsoft.AspNetCore.Mvc;

namespace BP_POC.Management.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopController : ControllerBase
{
    private readonly IShopService _shopService;

	public ShopController(IShopService shopService)
	{
		_shopService = shopService;
	}

	[HttpPost]
	public async Task<int> CreateAsync([FromBody] ShopDto.Mutate model)
	{
		return await _shopService.CreateAsync(model);
	}

	[HttpGet]
	public async Task<List<ShopDto.Index>> GetIndexAsync()
	{
		return await _shopService.GetIndexAsync();
	}

	[HttpGet("{id}")]
	public async Task<ShopDto.Detail> GetByIdAsync(int id)
	{
		return await _shopService.GetByIdAsync(id);
	}

	[HttpPut("AddPrinter")]
	public async Task<int> CreatePrinterAsync([FromBody] ShopRequest.PrinterMutate request)
	{
		return await _shopService.CreatePrinterAsync(request);
	}

	[HttpPut("RemovePrinter")]
	public async Task<IActionResult> DeletePrinterAsync([FromBody] ShopRequest.PrinterDelete request)
	{
		await _shopService.DeletePrinterAsync(request);
		return Ok();
	}

    [HttpGet("{id}/endofday")]
    public async Task<bool> RegisterEndOfDay(int id)
    {
        await _shopService.RegisterEndOfDay(id);
		return true;
    }
}
