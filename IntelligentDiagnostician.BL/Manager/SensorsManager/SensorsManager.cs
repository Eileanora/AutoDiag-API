using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Utils.Mapper.ConverterFactory;
using IntelligentDiagnostician.DAL.Repositories.SensorRepository;
using IntelligentDiagnostician.DataModels.Models;


namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public class SensorsManager : ISensorsManager
{
    private readonly ISensorRepository _sensorRepository;

    public SensorsManager(ISensorRepository sensorRepository)
    {
        _sensorRepository = sensorRepository;
    }
    
    public async Task<IEnumerable<SensorDto>> GetAllAsync(int systemId)
    {
        var sensors = await _sensorRepository.GetAllAsync(systemId);
        return sensors.Select(s => new SensorDto
        {
            Id = s.Id,
            SensorName = s.SensorName,
        });
    }
    
    public async Task<SensorDto?> GetByIdAsync(int systemId, int sensorId)
    {
        var sensor = await _sensorRepository.GetByIdAsync(systemId, sensorId);
        if (sensor == null)
            return null;
        
        return new SensorDto
        {
            Id = sensor.Id,
            SensorName = sensor.SensorName,
            CarSystemName = sensor.CarSystem.CarSystemName,
            CreatedBy = 1,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = 1,
            ModifiedDate = sensor.ModifiedDate
        };
    }

    public async Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor)
    {
        var newSensor = await _sensorRepository.CreateAsync(new Sensor
        {
            SensorName = sensor.SensorName,
            CarSystemId = systemId
        });
        if (newSensor == null)
            return null;
        
        return new SensorDto
        {
            Id = newSensor.Id,
            SensorName = newSensor.SensorName,
            CarSystemId = systemId,
            CreatedBy = 1,
            CreatedDate = newSensor.CreatedDate,
        };
    }

    public async  Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _sensorRepository.GetByIdAsync(id);
        if (toDelete == null)
            return false;
        await _sensorRepository.DeleteAsync(toDelete);
        return true;
    }
    
    public async Task<bool> SensorExistsAsync(int id)
    {
        return await _sensorRepository.SensorExistsAsync(id);
    }
    
    public async Task UpdateAsync(int sensorId, SensorForUpdateDto sensorForUpdate)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorId);
        sensor!.SensorName = sensorForUpdate.SensorName;
        sensor.CarSystemId = sensorForUpdate.CarSystemId;
        await _sensorRepository.UpdateAsync(sensor);
    }
}
