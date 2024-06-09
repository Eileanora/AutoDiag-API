using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.BL.Manager.ReadingManager;

public interface IReadingManager
{
    Task CreateAsync(Guid userId, Dictionary<int, float> readings);
    Task<PagedList<ReadingDto>> GetAllAsync(
        int sensorId,
        ReadingResourceParameters readingResourceParameters);
}
