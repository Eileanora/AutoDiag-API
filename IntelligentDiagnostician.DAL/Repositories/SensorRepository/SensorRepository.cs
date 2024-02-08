﻿using System.Runtime.CompilerServices;
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
    public new async Task<IEnumerable<Sensor>> GetAllAsync()
    {
        return await _context.Sensors
            .Include(s => s.CarSystem)
            .ToListAsync();
    }
    public new async Task<Sensor?> GetByIdAsync(int id)
    {
        return await _context.Sensors
            .Include(s => s.CarSystem)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}