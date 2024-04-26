using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.BL.Manager.ReadingManager;

public interface IReadingManager
{
    Task CreateAsync(int sensorId, Guid userId, float value);
    Task<PagedList<ReadingDto>> GetAllAsync(
        int sensorId,
        ReadingResourceParameters readingResourceParameters);
}
