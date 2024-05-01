using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.UnitOfWork;

namespace IntelligentDiagnostician.DAL.Repositories;


internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }
    
    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
    
    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
