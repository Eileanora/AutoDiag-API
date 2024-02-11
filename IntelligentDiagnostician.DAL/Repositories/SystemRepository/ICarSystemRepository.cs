using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;
namespace IntelligentDiagnostician.DAL.Repositories.SystemRepository;

public interface ICarSystemRepository : IBaseRepository<CarSystem>
{
    Task<bool> CarSystemExistsAsync(int id);
    new Task<CarSystem?> GetByIdAsync(int id);
}
