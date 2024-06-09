using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Manager.ReadingManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;

public interface IReadingControllerFacade
{
    IReadingManager ReadingManager { get; }
    ISensorsManager SensorManager { get; }
    IPaginationHelper<ReadingDto, ReadingResourceParameters> PaginationHelper { get; }
}
