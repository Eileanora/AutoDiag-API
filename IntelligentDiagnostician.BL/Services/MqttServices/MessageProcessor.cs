using System.Text.Json;
using FluentValidation;
using IntelligentDiagnostician.BL.Manager.FaultManager;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentDiagnostician.BL.Services.MqttServices;

public class MessageProcessor : IMessageProcessor
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MessageProcessor(
        IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task SaveData(Guid topic, Dictionary<int, float> sensorReadings, List<string> errors)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var readingManager = scope.ServiceProvider.GetRequiredService<IReadingManager>();
            await readingManager.CreateAsync(topic, sensorReadings);

            var errorManager = scope.ServiceProvider.GetRequiredService<IFaultManager>();
            await errorManager.CreateAsync(topic, errors);
        }
    }
    public (int, float)? ProcessSensorData(string sensorId, string strDivider, string value)
    {
        if (!int.TryParse(value, out var valueInt)   ||
            !int.TryParse(strDivider, out var divider) ||
            !int.TryParse(sensorId, out var sensorIdInt) ||
            divider <= 0)
            return null;
        
        var floatValue = (float)valueInt / divider;
        return (sensorIdInt, floatValue);
    }

    public async Task ProcessMessage(string topic, Dictionary<string, string> message)
    {
        if (!Guid.TryParse(topic, out var userId))
            return;
        
        // using (var scope = _serviceScopeFactory.CreateScope())
        // {
        //     var userValidator = scope.ServiceProvider.GetRequiredService<IValidator<Guid>>();
        //     var validationResult = await userValidator.ValidateAsync(userId);
        //     if (!validationResult.IsValid)
        //         return;
        // }       
        
        var sensorReadings = new Dictionary<int, float>();
        var errors = new List<string>();
        
        foreach(var key in message.Keys)
        {
            var args = key.Split("_");

            if (args.Length == 3 && args[0] == "s")
            {
                var sensorData = ProcessSensorData(args[1], args[2], message[key]);
                if (sensorData.HasValue)
                    sensorReadings[sensorData.Value.Item1] = sensorData.Value.Item2;
            }
            else if (args.Length == 2 && args[0] == "t")
            {
                errors.Add(message[key]);
            }
        }
        
        await SaveData(userId, sensorReadings, errors);
    }
}
