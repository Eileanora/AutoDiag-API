using IntelligentDiagnostician.BL.Dtos.SensorDTOs;

namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public interface ISensorsManager
{
    Task<IEnumerable<SensorDto>> GetAllAsync();
    Task<SensorDto> GetByIdAsync(int id);
}
