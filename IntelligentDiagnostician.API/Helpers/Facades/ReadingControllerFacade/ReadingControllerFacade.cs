using IntelligentDiagnostician.API.Helpers.PaginationHelper.ReadingPaginationHelper;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;

public class ReadingControllerFacade : IReadingControllerFacade
{
    public IReadingManager ReadingManager { get; }
    public ISensorsManager SensorManager { get; }
    public IReadingPaginationHelper ReadingPaginationHelper { get; }
    
    public ReadingControllerFacade(
        IReadingManager readingManager,
        ISensorsManager sensorManager,
        IReadingPaginationHelper readingPaginationHelper)
    {
        ReadingManager = readingManager;
        SensorManager = sensorManager;
        ReadingPaginationHelper = readingPaginationHelper;
    }
}
