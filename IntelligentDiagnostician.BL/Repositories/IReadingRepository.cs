using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface IReadingRepository
{
    Task<PagedList<Reading>> GetAllAsync(
        int sensorId,
        string userId,
        ReadingResourceParameters resourceParameters);

    Task CreateAsync(Reading reading);
}
