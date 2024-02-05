using IntelligentDiagnostics.BL.Dtos.UserDTOs;

namespace IntelligentDiagnostics.BL.Mapper.UsersManager;

public interface IUsersManager
{
    Task<UserDto> GetUserById(int id);
}