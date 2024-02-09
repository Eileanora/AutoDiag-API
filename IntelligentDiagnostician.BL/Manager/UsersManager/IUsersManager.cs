using IntelligentDiagnostician.BL.Dtos.UserDTOs;

namespace IntelligentDiagnostician.BL.Manager.UsersManager;

public interface IUsersManager
{
    Task<UserDto> GetUserById(int id);
}