using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.API.Helpers.ExceptionHandler;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.FaultControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.AuthServices;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.API;

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
