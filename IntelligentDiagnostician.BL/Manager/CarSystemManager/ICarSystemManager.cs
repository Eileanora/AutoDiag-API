using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

namespace IntelligentDiagnostician.BL.Manager.CarSystemManager;

public interface ICarSystemManager
{
    Task<IEnumerable<CarSystemDto>?> GetAllAsync();
    Task<CarSystemDto?> GetByIdAsync(int id);
    Task<CarSystemDtoWithSensors?> GetByIdWithSensorsAsync(int id);
    
    //public Task<T> GetById<T>(int id, bool includeSensors) where T : BaseEntity;
}
