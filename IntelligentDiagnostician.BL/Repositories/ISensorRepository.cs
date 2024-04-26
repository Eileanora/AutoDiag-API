using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface ISensorRepository
{
    Task<PagedList<Sensor>> GetAllAsync(int systemId, SensorsResourceParameters resourceParameters);
    Task<Sensor?> GetByIdAsync(int sensorId);
    Task<bool> SensorExistsAsync(int id);
    Task<bool> IsNameUniqueAsync(int carSystemId, string sensorName);
    Task<bool> IsIdUniqueAsync(int id);
    Task <Sensor> CreateAsync(Sensor sensor);
    // add all methods from the base repository class
    Sensor Update(Sensor sensor);
    void Delete(Sensor sensor);
    
    Task<Sensor?> GetByNameAsync(string sensorName);
}