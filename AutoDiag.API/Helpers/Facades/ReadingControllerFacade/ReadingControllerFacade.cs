using AutoDiag.API.Helpers.PaginationHelper;
using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.Manager.ReadingManager;
using AutoDiag.BL.Manager.SensorsManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.ReadingControllerFacade;

public class ReadingControllerFacade : IReadingControllerFacade
{
    public IReadingManager ReadingManager { get; }
    public ISensorsManager SensorManager { get; }
    public IPaginationHelper<ReadingDto, ReadingResourceParameters> PaginationHelper { get; }
    
    public ReadingControllerFacade(
        IReadingManager readingManager,
        ISensorsManager sensorManager,
        IPaginationHelper<ReadingDto, ReadingResourceParameters> paginationHelper)
    {
        ReadingManager = readingManager;
        SensorManager = sensorManager;
        PaginationHelper = paginationHelper;
    }
}
