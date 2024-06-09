using AutoDiag.BL.Repositories;
using AutoDiag.DAL.Context;
using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDiag.DAL.Repositories;

internal class TroubleCodeRepository(AppDbContext context)
    : BaseRepository<TroubleCode>(context), ITroubleCodeRepository
{
    public Task<bool> ProblemCodeExistsAsync(string problemCode)
    {
        return context.TroubleCodes
            .AnyAsync(tc => tc.ProblemCode == problemCode);
    }
}
