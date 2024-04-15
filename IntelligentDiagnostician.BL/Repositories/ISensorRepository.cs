using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface ISensorRepository
{
    Task<PagedList<Sensor>> GetAllAsync(int systemId, SensorsResourceParameters resourceParameters);
    Task<Sensor?> GetByIdAsync(int sensorId);
    Task<bool> SensorExistsAsync(int id);
    Task<bool> IsNameUniqueAsync(int carSystemId, string sensorName);
    
    Task <Sensor> CreateAsync(Sensor sensor);
    // add all methods from the base repository class
    Task <Sensor> UpdateAsync(Sensor sensor);
    Task DeleteAsync(Sensor sensor);
    
    Task<Sensor?> GetByNameAsync(string sensorName);
}