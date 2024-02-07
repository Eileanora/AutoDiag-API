using IntelligentDiagnostician.BL.Dtos.SensorDTOs;
using IntelligentDiagnostician.DAL.Repositories.SensorRepository;

namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public class SensorsManager : ISensorsManager
{
    private readonly ISensorRepository _sensorRepository;
    public SensorsManager(ISensorRepository sensorRepository)
    {
        _sensorRepository = sensorRepository;
    }
    
    public async Task<IEnumerable<SensorDto>> GetAllAsync()
    {
        var sensors = await _sensorRepository.GetAllAsync();

        return sensors.Select(s => new SensorDto
        {
            Id = s.Id,
            Name = s.SensorName,
            CreatedBy = 1,
            CreatedDate = s.CreatedDate,
            ModifiedBy = 1,
            ModifiedDate = s.ModifiedDate
        });
    }
    
    public async Task<SensorDto> GetByIdAsync(int id)
    {
        var sensor = await _sensorRepository.GetByIdAsync(id);
        if (sensor == null)
            return null;
        
        return new SensorDto
        {
            Id = sensor.Id,
            Name = sensor.SensorName,
            CreatedBy =1,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = 1,
            ModifiedDate = sensor.ModifiedDate
        };
    }
}
