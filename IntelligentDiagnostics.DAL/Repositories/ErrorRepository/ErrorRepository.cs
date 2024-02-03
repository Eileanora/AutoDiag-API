using IntelligentDiagnostics.DAL.Context;
using IntelligentDiagnostics.DAL.Repositories.BaseRepository;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.ErrorRepository;

public class ErrorRepository : BaseRepository<Error>, IErrorRepository
{
    private readonly AppDbContext _context;
    public ErrorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
