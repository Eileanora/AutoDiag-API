using AutoDiag.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDiag.BL.DTOs.UserDtos;

namespace AutoDiag.BL.AuthServices
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(CreateUserDto createuser); 
        Task<AuthModel> LoginAsync(LoginUser loginuser);
        Task<string> AssignRolesToUser(AssignRolesToUser assignrolestouser);
        Task<AuthModel> ChangePassword(ChangePasswordDto changePassword);


    }
}
