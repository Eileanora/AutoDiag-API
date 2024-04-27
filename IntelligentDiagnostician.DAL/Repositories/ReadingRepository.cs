using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Helpers;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class ReadingRepository(AppDbContext context, ISortHelper<Reading> sortHelper)
    : BaseRepository<Reading>(context), IReadingRepository
{
    public new async Task CreateAsync(Reading reading)
    {
        await context.Readings.AddAsync(reading);
        await context.SaveChangesAsync();
    }

    public async Task<PagedList<Reading>> GetAllAsync(
        int sensorId,
        string userId,
        ReadingResourceParameters resourceParameters)
    {
        var collection = DbContext.Readings as IQueryable<Reading>;
        // filter by userId

        // collection = collection
        //     .Where(r => r.SensorId == sensorId
        //                 && r.UserId == userId)
        //     .Include(r => r.Sensor)
        //     .Include(r => r.TroubleCode);
        //
        // if (!string.IsNullOrWhiteSpace(resourceParameters.ProblemCode))
        // {
        //     var problemCode = resourceParameters.ProblemCode.Trim();
        //     collection = collection
        //         .Where(r => r.TroubleCode
        //                             .ProblemCode
        //                             .Contains(problemCode));
        // }
        // if (!string.IsNullOrWhiteSpace(resourceParameters.Severity))
        // {
        //     var severity = resourceParameters.Severity.Trim();
        //     collection = collection
        //         .Where(r => r.TroubleCode.Severity == severity);
        // }
        var sortedList =
            sortHelper.ApplySort(collection, resourceParameters.OrderBy);

        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
}
