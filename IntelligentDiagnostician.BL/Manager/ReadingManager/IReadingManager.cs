using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.BL.Manager.ReadingManager;

public interface IReadingManager
{
    Task CreateAsync(Guid userId, Dictionary<int, float> readings);
    Task<PagedList<ReadingDto>> GetAllAsync(
        int sensorId,
        ReadingResourceParameters readingResourceParameters);
}
