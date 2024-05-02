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
            options.EnableSensitiveDataLogging(); // Corrected line
        });

     //   var x = configuration.GetConnectionString("DefaultConnectionStrings"); 

        services.AddScoped<ICarSystemRepository, CarSystemRepository>();
        services.AddScoped<ISensorRepository, SensorRepository>();
        services.AddScoped<IReadingRepository, ReadingRepository>();
        services.AddScoped<IUnitOfWork, Repositories.UnitOfWork>();
        services.AddScoped<ISortHelper<CarSystem>, SortHelper<CarSystem>>();
        services.AddScoped<ISortHelper<Sensor>, SortHelper<Sensor>>();
        services.AddScoped<ISortHelper<Reading>, SortHelper<Reading>>();
        services.AddScoped<IErrorRepository, FaultRepository>();
        services.AddScoped<ISortHelper<Fault>, SortHelper<Fault>>();
        services.AddScoped<ITroubleCodeRepository, TroubleCodeRepository>();
        
        return services;
    }
}
