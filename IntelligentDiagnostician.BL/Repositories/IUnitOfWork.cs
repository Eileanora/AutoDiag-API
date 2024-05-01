using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.BL.Repositories;


public interface IUnitOfWork
{
    Task SaveAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
