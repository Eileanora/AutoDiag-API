using IntelligentDiagnostician.API.Helpers.PaginationHelper.ReadingPaginationHelper;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;

public interface IReadingControllerFacade
{
    IReadingManager ReadingManager { get; }
    ISensorsManager SensorManager { get; }
    IReadingPaginationHelper ReadingPaginationHelper { get; }
}
