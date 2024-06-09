using AutoDiag.BL.ResourceParameters;
using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Repositories;

public interface IReadingRepository
{
    Task<PagedList<Reading>> GetAllAsync(
        int sensorId,
        string userId,
        ReadingResourceParameters resourceParameters);

    Task CreateAsync(Reading reading);
}
