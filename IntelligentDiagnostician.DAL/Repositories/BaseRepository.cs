﻿using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DAL.Context;
using Microsoft.EntityFrameworkCore;


namespace IntelligentDiagnostician.DAL.Repositories;

internal abstract class BaseRepository<T>
    where T : class
{   
    protected readonly AppDbContext DbContext;
    protected BaseRepository(AppDbContext context)
    {
        DbContext = context;
    }
    public async Task<T?> CreateAsync(T entity)
    {
        var newEntry = await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return newEntry.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);
        await SaveChangesAsync();
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        return SaveChangesAsync();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await DbContext.SaveChangesAsync();
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
