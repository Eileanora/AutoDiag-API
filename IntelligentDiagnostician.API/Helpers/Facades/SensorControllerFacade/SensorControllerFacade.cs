using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
public class SensorControllerFacade : ISensorControllerFacade
{
    public ISensorsManager SensorsManager { get; }
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<SensorForCreationDto> CreationValidator { get; }
    public IValidator<SensorForUpdateDto> UpdateValidator { get; }
    public  ISensorPaginationHelper SensorPaginationHelper { get; }
    
    

    public SensorControllerFacade(
        ISensorsManager sensorManager,
        ICarSystemManager carSystemManager,
        IValidator<SensorForCreationDto> creationValidator,
        IValidator<SensorForUpdateDto> updateValidator,
        ISensorPaginationHelper sensorPaginationHelper)
    {
        SensorsManager = sensorManager;
        CarSystemManager = carSystemManager;
        CreationValidator = creationValidator;
        UpdateValidator = updateValidator;
        SensorPaginationHelper = sensorPaginationHelper;
    }
}
