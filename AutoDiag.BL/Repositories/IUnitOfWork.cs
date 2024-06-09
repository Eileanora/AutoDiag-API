using Microsoft.EntityFrameworkCore;

namespace AutoDiag.BL.Repositories;


public interface IUnitOfWork
{
    Task SaveAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
