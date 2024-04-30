using System.Text.Json;
using FluentValidation;
using IntelligentDiagnostician.BL.Manager.ErrorManager;
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

            var errorManager = scope.ServiceProvider.GetRequiredService<IErrorManager>();
            await errorManager.CreateAsync(topic, errors);
        }
    }
    public (int, float)? ProcessSensorData(string sensorId, string value)
    {
        var values = value.Split(",");
        if (values.Length != 2)
            return null;
        if (!int.TryParse(values[0], out var valueInt)   ||
            !int.TryParse(values[1], out var divider) ||
            !int.TryParse(sensorId, out var sensorIdInt) ||
            divider <= 0)
            return null;
        
        var floatValue = (float)valueInt / divider;
        return (sensorIdInt, floatValue);
    }

    public async Task ProcessMessage(string topic, string payload)
    {
        var message = JsonSerializer.Deserialize<Dictionary<string, string>>(payload);
        if (message is null)
            return;
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

            if(args.Length != 2)
                continue;
            if (args[0] == "s")
            {
                var sensorData = ProcessSensorData(args[1], message[key]);
                if (sensorData.HasValue)
                    sensorReadings[sensorData.Value.Item1] = sensorData.Value.Item2;
            }
            else if (args[0] == "t")
            {
                errors.Add(message[key]);
            }
        }
        
        await SaveData(userId, sensorReadings, errors);
    }
}
