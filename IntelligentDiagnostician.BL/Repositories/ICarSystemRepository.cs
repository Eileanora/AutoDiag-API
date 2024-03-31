using IntelligentDiagnostician.DataModels.Models;


namespace IntelligentDiagnostician.BL.Repositories;

public interface ICarSystemRepository
{
    Task<bool> CarSystemExistsAsync(int id);
    Task<IEnumerable<CarSystem>> GetAllAsync();
    new Task<CarSystem?> GetByIdAsync(int id);
    
    Task <CarSystem> CreateAsync(CarSystem carSystem);
    // add all methods from the base repository class
    Task <CarSystem> UpdateAsync(CarSystem carSystem);
    Task DeleteAsync(CarSystem carSystem);
}