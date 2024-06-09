using AutoDiag.API.Helpers.PaginationHelper;
using FluentValidation;
using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.Manager.CarSystemManager;
using AutoDiag.BL.Manager.SensorsManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.SensorControllerFacade;

public interface ISensorControllerFacade
{
    public ISensorsManager SensorsManager { get; }
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<SensorForCreationDto> CreationValidator { get; }
    public IValidator<SensorForUpdateDto> UpdateValidator { get; }
    public IPaginationHelper<SensorDto, SensorsResourceParameters> PaginationHelper { get; }
}
