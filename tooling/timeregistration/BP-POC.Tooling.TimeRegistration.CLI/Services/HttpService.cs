using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace BP_POC.Tooling.TimeRegistration.CLI.Services;

public class HttpService
{
	private readonly HttpClient _client;
	private readonly string _endpoint;

	public HttpService(string baseUri, string endpoint)
	{
		_client = new HttpClient();
		_client.BaseAddress = new Uri(baseUri);

		_endpoint = endpoint;	
	}

	public async Task<DateTime?> CallRegisterPrinterClick(int printerId)
	{
		var response = await _client.PatchAsync($"{_endpoint}/{printerId}", null);

		if (response.IsSuccessStatusCode)
		{
			return DateTime.Now;
		}
		else
		{
			return null;
		}
	}
}
