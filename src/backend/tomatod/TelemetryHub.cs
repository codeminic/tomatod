using Microsoft.AspNetCore.SignalR;

namespace tomatod.API;

public interface ITelemetryHub
{
    Task SendState(string jsonState);
}

public class TelemetryHub : Hub<ITelemetryHub>
{
    public async Task SendHumidity(string jsonState) => await Clients.All.SendState(jsonState);
}
