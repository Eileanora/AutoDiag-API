using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;

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
