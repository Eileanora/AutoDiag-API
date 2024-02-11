using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories.SystemRepository;

public class CarSystemRepository : BaseRepository<CarSystem>, ICarSystemRepository
{
    private readonly AppDbContext _context;
    public CarSystemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public new async Task<CarSystem?> GetByIdAsync(int id)
    {
        return await _context.CarSystems
            .Include(cs => cs.Sensors)
            .FirstOrDefaultAsync(cs => cs.Id == id);
    }
    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await _context.CarSystems.AnyAsync(cs => cs.Id == id);
    }
}
