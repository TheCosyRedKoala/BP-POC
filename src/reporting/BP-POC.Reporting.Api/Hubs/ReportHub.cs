using Microsoft.AspNetCore.SignalR;

namespace BP_POC.Reporting.Api.Hubs;

public class ReportHub : Hub
{
    public async Task NotifyNewReport()
    {
        await Clients.All.SendAsync("NotifyNewReport");
    }
}
