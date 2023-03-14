using Microsoft.AspNetCore.SignalR;

namespace BP_POC.Operations.Api.Hubs;

public class PrinterHub : Hub
{
    public async Task SendPrintClick(int printerId)
    {
        await Clients.All.SendAsync("ReceivePrintClick", printerId);
    }
}
