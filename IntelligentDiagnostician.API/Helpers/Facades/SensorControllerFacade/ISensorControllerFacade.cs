using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;

public interface ISensorControllerFacade
{
    public ISensorsManager SensorsManager { get; }
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<SensorForCreationDto> CreationValidator { get; }
    public IValidator<SensorForUpdateDto> UpdateValidator { get; }
    public ISensorPaginationHelper SensorPaginationHelper { get; }
}