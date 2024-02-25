using System.Runtime.CompilerServices;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories.SensorRepository;

public  class SensorRepository : BaseRepository<Sensor>, ISensorRepository
{
    private readonly AppDbContext _context;
    public SensorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public new async Task<IEnumerable<Sensor>> GetAllAsync(int systemId)
    {
        return await _context.Sensors
            .Where(s => s.CarSystemId == systemId)
            .Include(s => s.CarSystem)
            .ToListAsync();
    }
    public async Task<Sensor?> GetByIdAsync(int systemId, int id)
    {
        return await _context.Sensors
            .Include(s => s.CarSystem)
            .FirstOrDefaultAsync(s => s.Id == id && s.CarSystemId == systemId);
    }
    public async Task<bool> SensorExistsAsync(int id)
    {
        return await _context.Sensors.AnyAsync(s => s.Id == id);
    }
}
