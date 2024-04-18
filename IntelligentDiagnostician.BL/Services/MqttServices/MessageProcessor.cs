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
        if (!int.TryParse(sensorId, out var sensorIdInt))
            return;
        if (!int.TryParse(value, out var valueInt))
            return;

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var readingManager = scope.ServiceProvider.GetRequiredService<IReadingManager>();
            await readingManager.CreateAsync(sensorIdInt, Guid.Parse(topic), valueInt);
        }
    }

    public async Task ProcessMessage(string topic, string payload)
    {
        var message2 = JsonSerializer.Deserialize<Dictionary<string, string>>(payload);
        foreach(var key in message2.Keys)
        {
            var args = key.Split("_");
            if(args.Length != 2)
                continue;
            if (args[0] == "s")
            {
                await ProcessSensorData(topic, args[1], message2[key]);
            }
        }
    }
}