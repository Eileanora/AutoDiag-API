using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class CarSystemRepository : BaseRepository<CarSystem>, ICarSystemRepository
{
    public CarSystemRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<CarSystem?> GetByIdAsync(int id)
    {
        
        return await DbContext.CarSystems
            .Include(cs => cs.Sensors)
            .FirstOrDefaultAsync(cs => cs.Id == id);
    }
    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await DbContext.CarSystems.AnyAsync(cs => cs.Id == id);
    }
}
