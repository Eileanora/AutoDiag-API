using IntelligentDiagnostics.BL.Dtos.SensorDTOs;
using IntelligentDiagnostics.BL.Mapper.UsersManager;
using IntelligentDiagnostics.DAL.Repositories.SensorRepository;
using IntelligentDiagnostics.DAL.Repositories.UserRepository;

namespace IntelligentDiagnostics.BL.Mapper.SensorsManager;

public class SensorsManager : ISensorsManager
{
    private readonly ISensorRepository _sensorRepository;
    private readonly IUsersManager _usersManager;
    public SensorsManager(ISensorRepository sensorRepository, IUsersManager usersManager)
    {
        _sensorRepository = sensorRepository;
        _usersManager = usersManager;
    }
    
    public async Task<IEnumerable<SensorDto>> GetAllAsync()
    {
        var sensors = await _sensorRepository.GetAllAsync();

        return sensors.Select(s => new SensorDto
        {
            Id = s.Id,
            Name = s.SensorName,
            CreatedBy = _usersManager.GetUserById(s.CreatedBy).Result.Name,
            CreatedDate = s.CreatedDate,
            ModifiedBy = _usersManager.GetUserById(s.ModifiedBy).Result.Name,
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
            CreatedBy = _usersManager.GetUserById(sensor.CreatedBy).Result.Name,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = _usersManager.GetUserById(sensor.ModifiedBy).Result.Name,
            ModifiedDate = sensor.ModifiedDate
        };
    }
}
