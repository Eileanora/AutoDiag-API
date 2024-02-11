using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories.BaseRepository;

public class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _context;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<T?> CreateAsync(T entity)
    {
        try
        {
            var newEntry = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntry.Entity;
        }
        catch (Exception ex)
        {
            // Log the exception details
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        return SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
