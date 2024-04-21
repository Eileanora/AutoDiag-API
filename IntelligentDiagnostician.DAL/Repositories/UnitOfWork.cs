﻿using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;

namespace IntelligentDiagnostician.DAL.Repositories;


internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}