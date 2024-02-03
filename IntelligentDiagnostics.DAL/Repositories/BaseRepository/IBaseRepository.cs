using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.GenereicRepository;

public interface IBaseRepository <T> where T : BaseEntity
{
    Task AddAsync(T entity) ;
    Task UpdateAsync(T entity) ;
    Task DeleteAsync(T entity) ;
    Task GetByIdAsync(int id) ;
    Task GetAllAsync() ;
    Task SaveChangesAsync();
}
