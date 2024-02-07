using System.Runtime.CompilerServices;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.Repositories.SensorRepository;

public  class SensorRepository : BaseRepository<Sensor>, ISensorRepository
{
    private readonly AppDbContext _context;
    public SensorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}