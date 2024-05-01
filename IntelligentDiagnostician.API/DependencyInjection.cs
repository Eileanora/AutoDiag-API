using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.API.Helpers.ExceptionHandler;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.FaultControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.API.Helpers.PaginationHelper.ReadingPaginationHelper;
using IntelligentDiagnostician.API.Helpers.PaginationHelper.SensorPaginationHelper;
using IntelligentDiagnostician.API.Helpers.PaginationHelper.CarSystemPaginationHelper;
using IntelligentDiagnostician.API.Helpers.PaginationHelper.FaultPaginationHelper;
using IntelligentDiagnostician.BL.AuthServices;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.API;

public static class DependencyInjection
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ICarSystemPaginationHelper, CarSystemPaginationHelper>();
        services.AddScoped<ISensorPaginationHelper, SensorPaginationHelper>();
        services.AddScoped<IReadingPaginationHelper, ReadingPaginationHelper>();
        services.AddScoped<IFaultPaginationHelper, FaultPaginagtionHelper>();
        
        services.AddScoped<ICarSystemControllerFacade, CarSystemControllerControllerFacade>();
        services.AddScoped<ICarSystemCollectionControllerFacade, CarSystemCollectionControllerFacade>();
        services.AddScoped<IReadingControllerFacade, ReadingControllerFacade>();
        services.AddScoped<ISensorControllerFacade, SensorControllerFacade>();
        services.AddScoped<IFaultControllerFacade, FaultControllerFacade>();
        
        services.AddScoped<IAuthService , AuthService>();
        
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<UnauthorizedAccessExceptionHandler>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddProblemDetails();
    }
}
