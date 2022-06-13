using MQTTnet;
using MQTTnet.Client;

namespace tomatod;
public class Greenhouse
{
    private readonly IConfiguration _configuration;

    public Greenhouse(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task OpenShutter()
    {
        using var client = await GetMqttClient();

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("greenhouse/shutter")
            .WithPayload("open")
            .Build();

        await client.PublishAsync(message, CancellationToken.None);
    }

    public async Task CloseShutter()
    {
        using var client = await GetMqttClient();

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("greenhouse/shutter")
            .WithPayload("close")
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
