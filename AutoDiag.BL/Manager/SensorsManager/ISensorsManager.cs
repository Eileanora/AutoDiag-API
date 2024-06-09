using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.BL.Manager.SensorsManager;

public interface ISensorsManager
{
    Task<PagedList<SensorDto>> GetAllAsync(int systemId, SensorsResourceParameters resourceParameters);
    Task<SensorDto?> GetByIdAsync(int sensorId);
    Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor);
    Task DeleteAsync(SensorDto sensorToDelete);
    Task UpdateAsync(int sensorId, SensorForUpdateDto sensorToPatch);
    Task <bool> SensorExistsAsync(int sensorId);
}
