using FluentValidation;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.Services.MqttServices;
using Microsoft.Extensions.DependencyInjection;
using IntelligentDiagnostician.BL.Utils.Facades.CarSystemManagerFacade;
using IntelligentDiagnostician.BL.Utils.Facades.ReadingManagerFacade;
using IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;
using IntelligentDiagnostician.BL.Utils.Validator.CarSystemValidators;
using MQTTnet;
using MQTTnet.Client;

namespace IntelligentDiagnostician.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddBlServices(this IServiceCollection services)
    {
        services.AddScoped<ICarSystemManager, CarSystemManager>();
        services.AddScoped<ISensorsManager, SensorsManager>();
        services.AddScoped<IReadingManager, ReadingManager>();
        services.AddScoped<ICarSystemManagerFacade, CarSystemManagerFacade>();
        services.AddScoped<ISensorManagerFacade, SensorManagerFacade>();
        services.AddScoped<IReadingManagerFacade, ReadingManagerFacade>();
        services.AddValidatorsFromAssemblyContaining<CarSystemDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CarSystemCollectionForCreationValidator>();
        
        #region MQTT Configuration

        services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        services.AddSingleton<IMqttService, MqttService>();
        services.AddSingleton<IMessageProcessor, MessageProcessor>();


        #endregion
        
        
        return services;
    }
}
