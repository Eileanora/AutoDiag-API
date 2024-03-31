using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace IntelligentDiagnostician.BL;

public static class ServiceRegister
{
    public static IServiceCollection AddBlServices(this IServiceCollection services)
    {
        services.AddScoped<ICarSystemManager, CarSystemManager>();
        services.AddScoped<ISensorsManager, SensorsManager>();
        services.AddAutoMapper(
            AppDomain.CurrentDomain.GetAssemblies());
        
        return services;
    }
}
