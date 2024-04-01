using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
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
        return sensors.Select(s => s.ToListDto());
    }
    
    public async Task<SensorDto?> GetByIdAsync(int sensorId)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorId);
        if (sensor == null)
            return null;
        
        return sensor.ToDto();
    }

    public async Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor)
    {
        var newSensor = await _sensorRepository.CreateAsync(sensor.ToEntity(systemId));
        if (newSensor == null)
            return null;
        
        return newSensor.ToDto();
    }

    public async Task DeleteAsync(SensorDto sensorToDelete)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorToDelete.Id);
        await _sensorRepository.DeleteAsync(sensor);
    }
    
    
    public async Task UpdateAsync(int sensorId, SensorForUpdateDto sensorForUpdate)
    {
        var sensor = await _sensorRepository.GetByIdAsync(sensorId);
        sensor.SensorName = sensorForUpdate.SensorName;
        sensor.CarSystemId = sensorForUpdate.CarSystemId;
        await _sensorRepository.UpdateAsync(sensor);
    }
}
