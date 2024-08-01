using AutoDiag.API.Helpers;
using AutoDiag.API.Helpers.ExceptionHandler;
using AutoDiag.API.Helpers.Facades.CarSystemCollectionControllerFacade;
using AutoDiag.API.Helpers.Facades.CarSystemControllerFacade;
using AutoDiag.API.Helpers.Facades.FaultControllerFacade;
using AutoDiag.API.Helpers.Facades.ReadingControllerFacade;
using AutoDiag.API.Helpers.Facades.SensorControllerFacade;
using AutoDiag.API.Helpers.PaginationHelper;
using AutoDiag.BL.Services.AuthServices;
using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.BL.Services.CurrentUserService;

namespace AutoDiag.API;

public static class DependencyInjection
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IPaginationHelper<CarSystemDto, CarSystemsResourceParameters>,
            PaginationHelper<CarSystemDto, CarSystemsResourceParameters>>();
        services.AddScoped<IPaginationHelper<SensorDto, SensorsResourceParameters>,
            PaginationHelper<SensorDto, SensorsResourceParameters>>();
        services.AddScoped<IPaginationHelper<ReadingDto, ReadingResourceParameters>,
            PaginationHelper<ReadingDto, ReadingResourceParameters>>();
        services.AddScoped<IPaginationHelper<FaultDto, FaultsResourceParameters>,
            PaginationHelper<FaultDto, FaultsResourceParameters>>();
        
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
