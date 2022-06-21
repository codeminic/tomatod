using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Diagnostics;

namespace tomatod
{
    public class MqttListener : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MqttListener> _logger;

        public MqttListener(IConfiguration configuration, ILogger<MqttListener> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting mqtt listener..");
            var mqttFactory = new MqttFactory();
            var mqttClient = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_configuration["mqtt:url"], int.Parse(_configuration["mqtt:port"]))
                .WithCredentials(_configuration["mqtt:username"], _configuration["mqtt:password"])
                .WithTls()
                .Build();

            await mqttClient.ConnectAsync(options);

            mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;

            await mqttClient.SubscribeAsync(new MqttClientSubscribeOptionsBuilder().WithTopicFilter("greenhouse/telemetry/#").Build(), CancellationToken.None);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

        }

        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            _logger.LogInformation($"Received message on topic {arg.ApplicationMessage.Topic}");
            _logger.LogInformation($"Payload: {arg.ApplicationMessage.ConvertPayloadToString()}");

            return Task.CompletedTask;
        }
    }
}
