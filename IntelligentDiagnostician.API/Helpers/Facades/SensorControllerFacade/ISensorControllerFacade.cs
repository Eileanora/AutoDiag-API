using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;

public interface ISensorControllerFacade
{
    public ISensorsManager SensorsManager { get; }
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<SensorForCreationDto> CreationValidator { get; }
    public IValidator<SensorForUpdateDto> UpdateValidator { get; }
    public IPaginationHelper<SensorDto, SensorsResourceParameters> PaginationHelper { get; }
}
