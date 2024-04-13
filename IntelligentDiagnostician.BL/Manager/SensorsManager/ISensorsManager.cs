using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public interface ISensorsManager
{
    Task<PagedList<SensorDto>> GetAllAsync(int systemId, SensorsResourceParameters resourceParameters);
    Task<SensorDto?> GetByIdAsync(int sensorId);
    Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor);
    Task DeleteAsync(SensorDto sensorToDelete);
    Task UpdateAsync(int sensorId, SensorForUpdateDto sensorToPatch);
}
