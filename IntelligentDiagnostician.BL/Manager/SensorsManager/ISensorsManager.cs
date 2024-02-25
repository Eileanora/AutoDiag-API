using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public interface ISensorsManager
{
    Task<IEnumerable<SensorDto>> GetAllAsync(int systemId);
    Task<SensorDto?> GetByIdAsync(int systemId, int sensorId);
    Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor);
    Task<bool> DeleteAsync(int id);
    Task UpdateAsync(int sensorId, SensorForUpdateDto sensorToPatch);
}
