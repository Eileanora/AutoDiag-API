using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.BL.DTOs.UserDtos;
using IntelligentDiagnostician.DataModels.Constants;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostician.BL.AuthServices
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

            await _userManager.AddToRoleAsync(User , ConstantRole.UserRole );   

            var JwtToken = await GenerateAccessToken(User);

            return new AuthModel
            {
                Message = "Succeeded",
                IsAuthenticated = true,
                Email = loginuser.Email,
                Token = JwtToken,
                Roles = new List<string> { ConstantRole.UserRole },
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
        private async Task<string> GenerateAccessToken(AppUser appUser)
        {

            var TokenHandler = new JwtSecurityTokenHandler();

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtoptions.Issuer,
                Audience = _jwtoptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.
                 UTF8.GetBytes(_configuration["SigningKey"])),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new(ClaimTypes.NameIdentifier, appUser.UserName),
                  new(ClaimTypes.Email, appUser.Email) ,
                })
            };

            var SecuirtyToken = TokenHandler.CreateToken(TokenDescriptor);

            var AccessToken = TokenHandler.WriteToken(SecuirtyToken);

            return AccessToken;
        }

       
    }
}
