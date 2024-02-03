using IntelligentDiagnostics.DAL.Context;
using IntelligentDiagnostics.DAL.Repositories.GenereicRepository;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.BaseRepository;

abstract class BaseRepository<T> : IBaseRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _context;
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        // await context.SaveChangesAsync();
    }
}
