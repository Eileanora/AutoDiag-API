using IntelligentDiagnostics.BL.Dtos.SensorDTOs;
namespace IntelligentDiagnostics.BL.Manager.SensorsManager;

public interface ISensorsManager
{
    Task<IEnumerable<SensorDto>> GetAllAsync();
    Task<SensorDto> GetByIdAsync(int id);
}
