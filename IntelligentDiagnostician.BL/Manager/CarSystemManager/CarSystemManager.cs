using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.DAL.Repositories.SystemRepository;
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
            // include only all sensors names in a list
            Sensors = system.Sensors.Select(s => s.SensorName).ToList(),
            CreatedBy = 1,
            CreatedDate = system.CreatedDate,
            ModifiedBy = 1,
            ModifiedDate = system.ModifiedDate
        };
    }

    public async Task<CarSystemDto?> CreateAsync(CarSystemForCreationDto systemFor)
    {
        var createdSystem = await _carSystemRepository.CreateAsync(new CarSystem
        {
            CarSystemName = systemFor.Name
        });
        if (createdSystem == null)
            return null;
        return new CarSystemDto
        {
            Id = createdSystem.Id,
            Name = createdSystem.CarSystemName,
            CreatedBy = 1,
            CreatedDate = createdSystem.CreatedDate
        };
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
        system!.CarSystemName = systemForUpdate.Name;
        await _carSystemRepository.UpdateAsync(system);
    }
}
