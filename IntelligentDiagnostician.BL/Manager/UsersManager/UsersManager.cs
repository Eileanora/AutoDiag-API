using IntelligentDiagnostician.BL.DTOs.UserDTOs;
using IntelligentDiagnostician.DAL.Repositories.UserRepository;
namespace IntelligentDiagnostician.BL.Manager.UsersManager;

public class UsersManager : IUsersManager
{
    private readonly IUserRepository _usersRepository;

    public UsersManager(IUserRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _usersRepository.GetByIdAsync(id);
        return new UserDto
        {
            Id = user.Id,
            Name = user.Fname + user.Lname,
        };
    }
}
