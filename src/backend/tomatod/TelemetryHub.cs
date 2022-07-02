using Microsoft.AspNetCore.SignalR;

namespace tomatod.API;

public interface ITelemetryHub
{
    Task SendLogMessage(string message);
}

public class TelemetryHub : Hub<ITelemetryHub>
{
    public async Task SendLogMessage(string message) => await Clients.All.SendLogMessage(message);
}
