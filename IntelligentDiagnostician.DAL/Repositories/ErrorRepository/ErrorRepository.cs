using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.BaseRepository;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.Repositories.ErrorRepository;

public class ErrorRepository : BaseRepository<Error>, IErrorRepository
{
    private readonly AppDbContext _context;
    public ErrorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
