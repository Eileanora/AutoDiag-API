using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.DAL.Repositories.SystemRepository;
using IntelligentDiagnostician.DAL.Repositories.UserRepository;

namespace IntelligentDiagnostician.BL.Manager.CarSystemManager;

public class CarSystemManager : ICarSystemManager
{
    private readonly ICarSystemRepository _carSystemRepository;
    private readonly IUserRepository _userRepository;
    public CarSystemManager(ICarSystemRepository carSystemRepository)
    {
        _carSystemRepository = carSystemRepository;
    }
    
    public async Task<IEnumerable<CarSystemDto>?> GetAllAsync()
    {
        var systems = await _carSystemRepository.GetAllAsync();
        return systems.Select(s => new CarSystemDto
                {
                    Id = s.Id,
                    Name = s.CarSystemName,
                });
    }
    
    public async Task<CarSystemDto?> GetByIdAsync(int id)
    {
        var system = await _carSystemRepository.GetByIdAsync(id);
        if(system == null)
            return null;
        
        return new CarSystemDto
        {
            Id = system.Id,
            Name = system.CarSystemName,
        };
    }
    public async Task<CarSystemDtoWithSensors?> GetByIdWithSensorsAsync(int id)
    {
        var system = await _carSystemRepository.GetByIdAsync(id);
        if(system == null)
            return null;
        
        return new CarSystemDtoWithSensors
        {
            Id = system.Id,
            Name = system.CarSystemName,
            // include only all sensors names in a list
            SensorsNames = system.Sensors.Select(s => s.SensorName).ToList(),
        };
    }
}
