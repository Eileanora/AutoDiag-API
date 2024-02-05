using System.Runtime.CompilerServices;
using IntelligentDiagnostics.DAL.Context;
using IntelligentDiagnostics.DAL.Repositories.BaseRepository;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.SensorRepository;

public  class SensorRepository : BaseRepository<Sensor>, ISensorRepository
{
    private readonly AppDbContext _context;
    public SensorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}