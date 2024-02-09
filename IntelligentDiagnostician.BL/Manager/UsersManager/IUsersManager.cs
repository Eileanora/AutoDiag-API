using IntelligentDiagnostician.BL.DTOs.UserDTOs;

namespace IntelligentDiagnostician.BL.Manager.UsersManager;

public interface IUsersManager
{
    Task<UserDto> GetUserById(int id);
}