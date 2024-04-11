using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
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
    
    public async Task<PagedList<Sensor>> GetAllAsync(
        int systemId,
        SensorsResourceParameters resourceParameters)
    {
        var collection = DbContext.Sensors as IQueryable<Sensor>;
        collection = collection.Where(s => s.CarSystemId == systemId);
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(s => s.SensorName.Contains(searchQuery));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.SensorName))
        {
            var name = resourceParameters.SensorName.Trim();
            collection = collection.Where(s => s.SensorName == name);
        }
        
        return await CreateAsync(
            collection,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
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

    public async Task<bool> IsNameUniqueAsync(int carSystemId, string sensorName)
    {
        return !await DbContext.Sensors
            .AnyAsync(s => s.CarSystemId == carSystemId && s.SensorName == sensorName);
    }
    
    public async Task<bool> IsNameUniqueAsync(int carSystemId, int sensorId, string sensorName)
    {
        return !await DbContext.Sensors
            .AnyAsync(s => s.CarSystemId == carSystemId
                           && s.SensorName == sensorName
                           && s.Id != sensorId);
    }
}
