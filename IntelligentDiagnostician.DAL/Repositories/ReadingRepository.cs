using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Helpers;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class ReadingRepository(
    AppDbContext context,
    ISortHelper<Reading> sortHelper)
    : BaseRepository<Reading>(context), IReadingRepository
{
    public new async Task CreateAsync(Reading reading)
    {
        await context.Readings.AddAsync(reading);
    }

    public async Task<PagedList<Reading>> GetAllAsync(
        int sensorId,
        string userId,
        ReadingResourceParameters resourceParameters)
    {
        var collection = DbContext.Readings as IQueryable<Reading>;
        // filter by userId

        collection = collection
            .Where(r => r.SensorId == sensorId
                        && r.UserId == userId)
            .Include(r => r.Sensor);

        var sortedList =
            sortHelper.ApplySort(collection, resourceParameters.OrderBy);

        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
}
