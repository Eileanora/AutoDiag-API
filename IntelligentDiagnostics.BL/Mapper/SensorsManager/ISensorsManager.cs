using IntelligentDiagnostics.BL.Dtos.SensorDTOs;
namespace IntelligentDiagnostics.BL.Mapper.SensorsManager;

public interface ISensorsManager
{
    Task<IEnumerable<SensorDto>> GetAllAsync();
    Task<SensorDto> GetByIdAsync(int id);
}
