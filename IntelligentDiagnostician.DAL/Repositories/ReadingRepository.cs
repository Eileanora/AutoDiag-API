using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class ReadingRepository(AppDbContext context)
    : BaseRepository<Reading>(context), IReadingRepository
{
    public new async Task CreateAsync(Reading reading)
    {
        await context.Readings.AddAsync(reading);
        await context.SaveChangesAsync();
    }
}
