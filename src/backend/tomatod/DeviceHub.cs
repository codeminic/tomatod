using Microsoft.AspNetCore.SignalR;

namespace tomatod;

public class DeviceHub : Hub
{
    private readonly ILogger<DeviceHub> _logger;

    public DeviceHub(ILogger<DeviceHub> logger)
    {
        _logger = logger;
    }

    public async Task WaterPlants()
    {
        await Clients.All.SendAsync("water-plants");
    }

    public async Task OpenShutter()
    {
        await Clients.All.SendAsync("open-shutter");
    }

    public async Task CloseShutter()
    {
        await Clients.All.SendAsync("close-shutter");
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Client connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Client disconnected: {Context.ConnectionId}");
        return base.OnDisconnectedAsync(exception);
    }
}