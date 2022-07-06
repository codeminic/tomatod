using MQTTnet;
using MQTTnet.Client;

namespace tomatod
{
    public class MqttListener : BackgroundService
    {
        private readonly GreenhouseStateManager _greenhouseStateManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<MqttListener> _logger;

        public MqttListener(GreenhouseStateManager greenhouseStateManager, IConfiguration configuration, ILogger<MqttListener> logger)
        {
            _greenhouseStateManager = greenhouseStateManager;
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
            var topic = arg.ApplicationMessage.Topic;
            var payload = arg.ApplicationMessage.ConvertPayloadToString();

            _logger.LogInformation($"Received message on topic {topic}");
            _logger.LogInformation($"Payload: {payload}");

            if (topic == "greenhouse/telemetry/temperature")
            {
                var temperature = float.Parse(payload);
                _greenhouseStateManager.Temperature = temperature;
            }
            else if(topic == "greenhouse/telemetry/humidity")
            {
                var humidity = float.Parse(payload);
                _greenhouseStateManager.Humidity = humidity;
            }
            else if (topic == "greenhouse/telemetry/shutter")
            {
                var state = (ShutterState)Enum.Parse(typeof(ShutterState), payload, true);
                _greenhouseStateManager.ShutterState = state;
            }

            return Task.CompletedTask;
        }
    }
}
