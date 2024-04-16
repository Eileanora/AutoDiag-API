using FluentValidation;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using Microsoft.Extensions.DependencyInjection;
using IntelligentDiagnostician.BL.Utils.Facades.CarSystemManagerFacade;
using IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;
using IntelligentDiagnostician.BL.Utils.Validator.CarSystemValidators;

namespace IntelligentDiagnostician.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddBlServices(this IServiceCollection services)
    {
        services.AddScoped<ICarSystemManager, CarSystemManager>();
        services.AddScoped<ISensorsManager, SensorsManager>();
        services.AddScoped<ICarSystemManagerFacade, CarSystemManagerFacade>();
        services.AddScoped<ISensorManagerFacade, SensorManagerFacade>();
        services.AddValidatorsFromAssemblyContaining<CarSystemDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CarSystemCollectionForCreationValidator>();
        return services;
    }
}
