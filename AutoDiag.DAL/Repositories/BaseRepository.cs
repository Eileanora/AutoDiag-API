using System.Linq.Expressions;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.DAL.Context;
using Microsoft.EntityFrameworkCore;


namespace AutoDiag.DAL.Repositories;

internal abstract class BaseRepository<T>
    where T : class
{   
    protected readonly AppDbContext DbContext;
    protected BaseRepository(AppDbContext context)
    {
        DbContext = context;
    }

    // public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    // {
    //     return DbContext.Set<T>().Where(expression).AsNoTracking();
    // }
        
    public async Task<T?> CreateAsync(T entity)
    {
        var newEntry = await DbContext.Set<T>().AddAsync(entity);
        return newEntry.Entity;
    }

    public T Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }
    
    
    public static async Task<PagedList<T>> CreateAsync(
        IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}
