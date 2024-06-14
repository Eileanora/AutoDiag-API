using AutoDiag.DataModels.Constants;
using AutoDiag.DataModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoDiag.BL.DTOs.UserDtos;
using AutoDiag.BL.Helpers;
using Microsoft.Extensions.Logging;

namespace AutoDiag.BL.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtOptions _jwtoptions;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager; 
        public AuthService(UserManager<AppUser> userManager , JwtOptions jwtOptions , RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            _jwtoptions = jwtOptions;   
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<AuthModel> RegisterAsync(CreateUserDto createuser)
        {
            if (await _userManager.FindByEmailAsync(createuser.Email) is not null)
                return new AuthModel { Message = " Email is already registered" };

            if (await _userManager.FindByNameAsync(createuser.UserName) is not null)
                return new AuthModel { Message = "User Name is already registered" };

            var User = new AppUser
            {
                FirstName = createuser.FristName,
                LastName = createuser.LastName,
                UserName = createuser.UserName,
                Email = createuser.Email,
            };

            var Result = await _userManager.CreateAsync(User, createuser.Password);

            if (!Result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in Result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(User, ConstantRole.UserRole);

            var  JwtToken = await GenerateAccessToken(User);

            return new AuthModel
            {
                Message = "Succeeded",
                IsAuthenticated = true,
                Id = User.Id,
                Email = User.Email,
                UserName = User.UserName,
                Token = JwtToken,
                Roles = new List<string> { ConstantRole.UserRole } 
            };
        }
        public async Task<AuthModel> LoginAsync(LoginUser loginuser)
        {
            var User = await _userManager.FindByEmailAsync(loginuser.Email);

            if (User == null || !await _userManager.CheckPasswordAsync(User, loginuser.Password))
                return new AuthModel { Message = "Email or Password is incorrect!" };

            var userRoles = await _userManager.GetRolesAsync(User);

            var JwtToken = await GenerateAccessToken(User);

            return new AuthModel
            {
                Message = "Succeeded",
                IsAuthenticated = true,
                Email = loginuser.Email,
                UserName = User.UserName,
                Token = JwtToken,
                Id = User.Id , 
                Roles = userRoles.ToList(),
            };
        }
        public async Task<string> AssignRolesToUser(AssignRolesToUser assignrolestouser) 
        {
            var UserId = await _userManager.FindByIdAsync(assignrolestouser.UserId);

            if (UserId is null)
                return "Invalid User Id";

            if (!await _roleManager.RoleExistsAsync(assignrolestouser.RoleName)) 
                return "Invalid Role Name";

            if (await _userManager.IsInRoleAsync(UserId, assignrolestouser.RoleName) == true)
                return "role is assined this user"; 

            var Result = await _userManager.AddToRoleAsync(UserId ,assignrolestouser.RoleName);

            return Result.Succeeded ? string.Empty : "Something Went Wrong";
        }
        public async Task<AuthModel> ChangePassword(ChangePasswordDto changePassword)
        {
            var User = await _userManager.FindByIdAsync(changePassword.UserId);

            if (User == null)
                return new AuthModel { Message = "Invalid User Id" };

            var result = await _userManager.ChangePasswordAsync(User, changePassword.OldPassword, changePassword.NewPassword);

            if (!result.Succeeded)
            {
                var erros = string.Empty;

                foreach (var error in result.Errors)
                {
                    erros += $"{error.Description},";
                }
                return new AuthModel { Message = erros };
            }

            return new AuthModel
            {
                Message = "Password changed successfully",
                IsAuthenticated = true
            };

        }
        private async Task<string> GenerateAccessToken(AppUser appUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, appUser.Id),
                new Claim(ClaimTypes.NameIdentifier, appUser.UserName),
                new Claim(ClaimTypes.Email, appUser.Email)
            });

            var roles = await _userManager.GetRolesAsync(appUser);
            foreach (var role in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtoptions.Issuer,
                Expires = DateTime.UtcNow.AddDays(_jwtoptions.Lifetime),
                Audience = _jwtoptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtoptions.SigningKey)),
                SecurityAlgorithms.HmacSha256),
                Subject = claims 
            };
         //   var x = _configuration["SigningKey"]; 

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
