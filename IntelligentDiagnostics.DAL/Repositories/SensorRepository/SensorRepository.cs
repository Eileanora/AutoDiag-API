using IntelligentDiagnostics.DAL.Context;
using IntelligentDiagnostics.DAL.Repositories.BaseRepository;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.SensorRepository;

internal  class SensorRepository : BaseRepository<Sensor>, ISensorRepository
{
    private readonly AppDbContext _context;
    SensorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
