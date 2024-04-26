using IntelligentDiagnostician.BL.DTOs.UserDtos;
using IntelligentDiagnostician.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostician.BL.AuthServices
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(CreateUserDto createuser); 
        Task<AuthModel> LoginAsync(LoginUser loginuser);
        Task<string> AssignRolesToUser(AssignRolesToUser assignrolestouser);
        Task<AuthModel> ChangePassword(ChangePasswordDto changePassword);


    }
}
