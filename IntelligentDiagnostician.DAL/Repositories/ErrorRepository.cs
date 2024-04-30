using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Helpers;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class ErrorRepository(
    AppDbContext context,
    ISortHelper<Error> sortHelper)
    : BaseRepository<Error>(context), IErrorRepository
{
    public new async Task CreateAsync(Error error)
    {
        await context.Errors.AddAsync(error);
    }

    public async Task<PagedList<Error>> GetAllAsync(
        string userId,
        ErrorsResourceParameters resourceParameters)
    {
        var collection = DbContext.Errors as IQueryable<Error>;
        // filter by userId
        collection = collection
            .Where(e => e.UserId == userId)
            .Include(e => e.TroubleCode)
            .ThenInclude(tc => tc.TroubleCodeLinks);
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.ProblemCode))
        {
            var problemCode = resourceParameters.ProblemCode.Trim();
            collection = collection
                .Where(e => e.TroubleCode
                                    .ProblemCode
                                    .Contains(problemCode));
        }
        if (!string.IsNullOrWhiteSpace(resourceParameters.Severity))
        {
            var severity = resourceParameters.Severity.Trim();
            if (int.TryParse(severity, out var severityInt))
            {
                collection = collection
                    .Where(r => r.TroubleCode.Severity == severityInt);
            }
        }
        
        var sortedList =
            sortHelper.ApplySort(collection, resourceParameters.OrderBy);

        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
}
