using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.Repositories.SystemRepository;

public class CarSystemRepository : BaseRepository<CarSystem>, ICarSystemRepository
{
    private readonly AppDbContext _context;
    CarSystemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
