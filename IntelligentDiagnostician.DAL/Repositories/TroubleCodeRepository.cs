using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class TroubleCodeRepository(AppDbContext context)
    : BaseRepository<TroubleCode>(context), ITroubleCodeRepository
{
    public Task<bool> ProblemCodeExistsAsync(string problemCode)
    {
        return context.TroubleCodes
            .AnyAsync(tc => tc.ProblemCode == problemCode);
    }
}
