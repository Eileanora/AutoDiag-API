using IntelligentDiagnostics.DAL.Context;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.SystemRepository;

public class CarSystemRepository : BaseRepository<CarSystem>, ICarSystemRepository
{
    private readonly AppDbContext _context;
    CarSystemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
