using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public interface ISensorsManager
{
    Task<IEnumerable<SensorDto>> GetAllAsync(int systemId);
    Task<SensorDto?> GetByIdAsync(int sensorId);
    Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor);
    Task DeleteAsync(SensorDto sensorToDelete);
    Task UpdateAsync(int sensorId, SensorForUpdateDto sensorToPatch);
}
