using System.Text.Json;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentDiagnostician.BL.Services.MqttServices;

public class MessageProcessor : IMessageProcessor
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MessageProcessor(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task ProcessSensorData(string topic, string sensorId, string value)
    {
        var values = value.Split(",");
        if (values.Length != 2)
            return;
        if (!int.TryParse(values[0], out var valueInt)   ||
            !int.TryParse(values[1], out var divider) ||
            !int.TryParse(sensorId, out var sensorIdInt) ||
            divider <= 0)
            return;
        
        var floatValue = (float)valueInt / divider;
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var readingManager = scope.ServiceProvider.GetRequiredService<IReadingManager>();
            await readingManager.CreateAsync(sensorIdInt, Guid.Parse(topic), floatValue);
        }
    }

    public async Task ProcessMessage(string topic, string payload)
    {
        var message = JsonSerializer.Deserialize<Dictionary<string, string>>(payload);
        foreach(var key in message.Keys)
        {
            var args = key.Split("_");
            if(args.Length != 2)
                continue;
            if (args[0] == "s")
            {
                await ProcessSensorData(topic, args[1], message[key]);
            }
        }
    }
}