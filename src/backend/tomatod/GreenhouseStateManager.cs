using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text.Json.Serialization;
using tomatod.API;

namespace tomatod
{
    public class GreenhouseStateManager
    {
        private readonly IHubContext<TelemetryHub, ITelemetryHub> _telemetryHubContext;

        public GreenhouseStateManager(IHubContext<TelemetryHub, ITelemetryHub> telemetryHubContext)
        {
            _telemetryHubContext = telemetryHubContext;
        }

        private ShutterState shutterState;

        public ShutterState ShutterState
        {
            get => shutterState;
            set
            {
                shutterState = value;
                NotifyClients();
            }
        }

        private float temperature;

        public float Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                NotifyClients();
            }
        }

        private float humidity;

        public float Humidity 
        { 
            get => humidity;
            set
            {
                humidity = value;
                NotifyClients();
            }
        }

        public void NotifyClients()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            _telemetryHubContext.Clients.All.SendState(JsonSerializer.Serialize(this, options));
        }
    }

    public enum ShutterState
    {
        Open,
        Opening,
        Closed,
        Closing
    }
}