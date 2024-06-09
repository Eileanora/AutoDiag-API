using AutoDiag.BL.Repositories;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.DAL.Context;
using AutoDiag.DAL.Helpers;
using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDiag.DAL.Repositories;

internal class FaultRepository(
    AppDbContext context,
    ISortHelper<Fault> sortHelper)
    : BaseRepository<Fault>(context), IErrorRepository
{
    public new async Task CreateAsync(Fault fault)
    {
        await context.Faults.AddAsync(fault);
    }

    public async Task<PagedList<Fault>> GetAllAsync(
        string userId,
        FaultsResourceParameters resourceParameters)
    {
        var collection = DbContext.Faults as IQueryable<Fault>;
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
