using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.API.Helpers.ExceptionHandler;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.AuthServices;
using IntelligentDiagnostician.BL.Services.CurrentUserService;
using IntelligentDiagnostician.BL.Services.UserSession;

namespace IntelligentDiagnostician.API;

public static class DependencyInjection
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<ICarSystemPaginationHelper, CarSystemPaginationHelper>();
        services.AddScoped<ISensorPaginationHelper, SensorPaginationHelper>();
        services.AddScoped<ICarSystemControllerFacade, CarSystemControllerControllerFacade>();
        services.AddScoped<ICarSystemCollectionControllerFacade, CarSystemCollectionControllerFacade>();
        services.AddScoped<ISensorControllerFacade, SensorControllerFacade>();
        services.AddScoped<IAuthService , AuthService>();
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddProblemDetails();
    }
}
