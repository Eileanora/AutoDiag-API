using IntelligentDiagnostics.BL.Dtos.UserDTOs;

namespace IntelligentDiagnostics.BL.Manager.UsersManager;

public interface IUsersManager
{
    Task<UserDto> GetUserById(int id);
}