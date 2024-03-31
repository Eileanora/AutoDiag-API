using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class SensorRepository : BaseRepository<Sensor>, ISensorRepository
{
    public SensorRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Sensor>> GetAllAsync(int systemId)
    {
        return await DbContext.Sensors
            .Where(s => s.CarSystemId == systemId)
            .Include(s => s.CarSystem)
            .ToListAsync();
    }
    public async Task<Sensor?> GetByIdAsync(int id)
    {
        return await DbContext.Sensors
            .Include(s => s.CarSystem)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<bool> SensorExistsAsync(int id)
    {
        return await DbContext.Sensors.AnyAsync(s => s.Id == id);
    }
}
