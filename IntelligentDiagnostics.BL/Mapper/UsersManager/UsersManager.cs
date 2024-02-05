using IntelligentDiagnostics.BL.Dtos.UserDTOs;
using IntelligentDiagnostics.DAL.Repositories.UserRepository;
namespace IntelligentDiagnostics.BL.Mapper.UsersManager;

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
