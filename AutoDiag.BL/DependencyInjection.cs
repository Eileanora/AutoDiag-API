using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.Manager.CarSystemManager;
using AutoDiag.BL.Manager.FaultManager;
using AutoDiag.BL.Manager.ReadingManager;
using AutoDiag.BL.Manager.SensorsManager;
using AutoDiag.BL.Services.MqttServices;
using AutoDiag.BL.Helpers.Facades.CarSystemManagerFacade;
using AutoDiag.BL.Helpers.Facades.FaultManagerFacade;
using AutoDiag.BL.Helpers.Facades.ReadingManagerFacade;
using AutoDiag.BL.Helpers.Facades.SensorManagerFacade;
using AutoDiag.BL.Helpers.Validator.CarSystemValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using MQTTnet.Client;

namespace AutoDiag.BL;

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
