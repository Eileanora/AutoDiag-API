using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Helpers;
using IntelligentDiagnostician.DAL.Interceptors;
using IntelligentDiagnostician.DAL.Repositories;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentDiagnostician.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<UpdateAuditFieldsInterceptor>();
        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var UpdateAuditFieldsInterceptor = sp.GetRequiredService<UpdateAuditFieldsInterceptor>();
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings"));
            options.AddInterceptors(UpdateAuditFieldsInterceptor);
        });
            
        services.AddScoped<ICarSystemRepository, CarSystemRepository>();
        services.AddScoped<ISensorRepository, SensorRepository>();
        services.AddScoped<IReadingRepository, ReadingRepository>();
        services.AddScoped<ISortHelper<CarSystem>, SortHelper<CarSystem>>();
        services.AddScoped<ISortHelper<Sensor>, SortHelper<Sensor>>();
        
        return services;
    }
}
