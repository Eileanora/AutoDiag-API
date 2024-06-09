using AutoDiag.API.Helpers.PaginationHelper;
using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.Manager.ReadingManager;
using AutoDiag.BL.Manager.SensorsManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.ReadingControllerFacade;

public interface IReadingControllerFacade
{
    IReadingManager ReadingManager { get; }
    ISensorsManager SensorManager { get; }
    IPaginationHelper<ReadingDto, ReadingResourceParameters> PaginationHelper { get; }
}
