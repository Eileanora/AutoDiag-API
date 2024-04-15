﻿using IntelligentDiagnostician.API.Helpers.ExceptionHandler;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.AuthServices;

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
        services.AddProblemDetails();
    }
}
