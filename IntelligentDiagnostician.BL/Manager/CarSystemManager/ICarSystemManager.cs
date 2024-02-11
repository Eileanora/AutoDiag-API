using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

namespace IntelligentDiagnostician.BL.Manager.CarSystemManager;

public interface ICarSystemManager
{
    Task<IEnumerable<CarSystemDto>?> GetAllAsync();
    Task<CarSystemDto?> GetByIdAsync(int id);
    Task<CarSystemDto?>? CreateAsync(CarSystemForCreationDto systemFor);
    Task<bool> DeleteAsync(int id);
    Task<bool> CarSystemExistsAsync(int id);

    //public Task<T> GetById<T>(int id, bool includeSensors) where T : BaseEntity;
}
