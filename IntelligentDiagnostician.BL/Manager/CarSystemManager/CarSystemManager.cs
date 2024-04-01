using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
using IntelligentDiagnostician.DataModels.Models;
namespace IntelligentDiagnostician.BL.Manager.CarSystemManager;

public class CarSystemManager : ICarSystemManager
{
    private readonly ICarSystemRepository _carSystemRepository;
    public CarSystemManager(ICarSystemRepository carSystemRepository)
    {
        _carSystemRepository = carSystemRepository;
    }
    
    public async Task<IEnumerable<CarSystemDto>?> GetAllAsync()
    {
        var systems = await _carSystemRepository.GetAllAsync();
        return systems.Select(s => s.ToListDto());
    }

    public async Task<CarSystemDto?> GetByIdAsync(int id)
    {
        var system = await _carSystemRepository.GetByIdAsync(id);
        if(system == null)
            return null;

        return system.ToDto();
    }

    public async Task<CarSystemDto?> CreateAsync(CarSystemForCreationDto systemFor)
    {
        var systemToCreate = new CarSystem
        {
            CarSystemName = systemFor.CarSystemName,
            Sensors = systemFor.Sensors != null
                ? systemFor.Sensors
                    .Select(s => new Sensor { SensorName = s.SensorName }).ToList()
                : null
        };
        var createdSystem = await _carSystemRepository.CreateAsync(systemToCreate);
        if (createdSystem == null)
            return null;
        return createdSystem.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var system = await _carSystemRepository.GetByIdAsync(id);
        if (system == null)
            return false;
        await _carSystemRepository.DeleteAsync(system);
        return true;
    }
    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await _carSystemRepository.CarSystemExistsAsync(id);
    }
    public async Task UpdateAsync(int systemId, CarSystemForUpdateDto systemForUpdate)
    {
        var system = await _carSystemRepository.GetByIdAsync(systemId);
        system!.CarSystemName = systemForUpdate.CarSystemName;
        await _carSystemRepository.UpdateAsync(system);
    }
}
