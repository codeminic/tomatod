using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Client;
using tomatod.API;

namespace tomatod;
public class Greenhouse
{
    private readonly IConfiguration _configuration;
    private readonly IHubContext<TelemetryHub, ITelemetryHub> _telemetryHubContext;

    public Greenhouse(IConfiguration configuration, IHubContext<TelemetryHub, ITelemetryHub> telemetryHubContext)
    {
        _configuration = configuration;
        _telemetryHubContext = telemetryHubContext;
    }

    public async Task OpenShutter()
    {
        using var client = await GetMqttClient();

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("greenhouse/shutter/open")
            .Build();

        await _telemetryHubContext.Clients.All.SendLogMessage("Fuck of mate! 🤌");

        await client.PublishAsync(message, CancellationToken.None);
    }

    public async Task CloseShutter()
    {
        using var client = await GetMqttClient();

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("greenhouse/shutter/close")
            .Build();

        await client.PublishAsync(message, CancellationToken.None);
    }

    public async Task WaterPlants()
    {
        using var client = await GetMqttClient();

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("greenhouse/water")
            .WithPayload("15s")
            .Build();

        await client.PublishAsync(message, CancellationToken.None);
    }

    private async Task<IMqttClient> GetMqttClient()
    {
        var mqttFactory = new MqttFactory();
        var mqttClient = mqttFactory.CreateMqttClient();
        var mqttClientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer(_configuration["mqtt:url"], int.Parse(_configuration["mqtt:port"]))
            .WithCredentials(_configuration["mqtt:username"], _configuration["mqtt:password"])
            .WithTls()
            .Build();

        await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
        return mqttClient;
    }
}
