using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface ISensorRepository
{
    Task<IEnumerable<Sensor>> GetAllAsync(int systemId);
    Task<Sensor?> GetByIdAsync(int sensorId);
    Task<bool> SensorExistsAsync(int id);
    
    Task <Sensor> CreateAsync(Sensor sensor);
    // add all methods from the base repository class
    Task <Sensor> UpdateAsync(Sensor sensor);
    Task DeleteAsync(Sensor sensor);
}