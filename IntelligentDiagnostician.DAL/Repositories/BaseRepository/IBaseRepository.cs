using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.Repositories.BaseRepository;

public interface IBaseRepository <T> where T : BaseEntity
{
    Task AddAsync(T entity) ;
    Task UpdateAsync(T entity) ;
    Task DeleteAsync(T entity) ;
    Task<T?> GetByIdAsync(int id) ;
    Task<IEnumerable<T> >GetAllAsync() ;
    Task SaveChangesAsync();
}
