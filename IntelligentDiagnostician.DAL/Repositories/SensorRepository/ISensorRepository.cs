using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.Repositories.SensorRepository;

public interface ISensorRepository : IBaseRepository<Sensor>
{
    Task<IEnumerable<Sensor>> GetAllAsync(int systemId);
    new Task<Sensor?> GetByIdAsync(int id);
}