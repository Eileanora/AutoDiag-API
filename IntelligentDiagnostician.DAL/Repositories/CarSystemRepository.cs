using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using IntelligentDiagnostician.DAL.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class CarSystemRepository(AppDbContext context, ISortHelper<CarSystem> sortHelper)
    : BaseRepository<CarSystem>(context), ICarSystemRepository
{

    public async Task<CarSystem?> GetByIdAsync(int id)
    {
        
        return await DbContext.CarSystems
            .Include(cs => cs.Sensors)
            .FirstOrDefaultAsync(cs => cs.Id == id);
    }
    public async Task<bool> IsNameUnique(string carSystemName)
    {
        return await DbContext.CarSystems
            .AnyAsync(cs => cs.CarSystemName == carSystemName);
    }
    public async Task<bool> IsNameUnique(int id, string carSystemName)
    {
        return await DbContext.CarSystems
            .Where(cs => cs.Id != id)
            .AnyAsync(cs => cs.CarSystemName == carSystemName);
    }

    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await DbContext.CarSystems.AnyAsync(cs => cs.Id == id);
    }

    public async Task<PagedList<CarSystem>> GetAllAsync(CarSystemsResourceParameters resourceParameters)
    {
        var collection = DbContext.CarSystems as IQueryable<CarSystem>;
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(cs => cs.CarSystemName.Contains(searchQuery));
        }
        // TODO: Find a better way to handle filtering
        if (!string.IsNullOrWhiteSpace(resourceParameters.CarSystemName))
        {
            var name = resourceParameters.CarSystemName.Trim();
            collection = collection.Where(cs => cs.CarSystemName == name);
        }
        
        var sortedList = sortHelper.ApplySort(collection, resourceParameters.OrderBy);
        
        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
}
