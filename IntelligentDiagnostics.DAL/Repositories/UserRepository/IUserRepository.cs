using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.DAL.Repositories.UserRepository;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetUserAsync(int userId);
}