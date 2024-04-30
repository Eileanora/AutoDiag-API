using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.FaultManager;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.Services.MqttServices;
using Microsoft.Extensions.DependencyInjection;
using IntelligentDiagnostician.BL.Utils.Facades.CarSystemManagerFacade;
using IntelligentDiagnostician.BL.Utils.Facades.FaultManagerFacade;
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
        services.AddScoped<ICarSystemManagerFacade, CarSystemManagerFacade>();
        services.AddScoped<ICarSystemManager, CarSystemManager>();

        services.AddScoped<ISensorManagerFacade, SensorManagerFacade>();
        services.AddScoped<ISensorsManager, SensorsManager>();

        
        services.AddScoped<IReadingManagerFacade, ReadingManagerFacade>();
        services.AddScoped<IReadingManager, ReadingManager>();
        
        services.AddScoped<IFaultManagerFacade, FaultManagerFacade>();
        services.AddScoped<IFaultManager, FaultManager>();
        
        services.AddValidatorsFromAssemblyContaining<CarSystemDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CarSystemCollectionForCreationValidator>();
        services.AddValidatorsFromAssemblyContaining<FaultForCreationDto>();
        
        #region MQTT Configuration

        services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        services.AddSingleton<IMqttService, MqttService>();
        services.AddSingleton<IMessageProcessor, MessageProcessor>();


        #endregion
        
        
        return services;
    }
}
