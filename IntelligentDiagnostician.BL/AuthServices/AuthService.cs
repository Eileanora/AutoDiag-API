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

            var userRoles = await _userManager.GetRolesAsync(User);

            var JwtToken = await GenerateAccessToken(User);

            return new AuthModel
            {
                Message = "Succeeded",
                IsAuthenticated = true,
                Email = loginuser.Email,
                Token = JwtToken,
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
        private async Task<string> GenerateAccessToken(AppUser appUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new ClaimsIdentity(new Claim[]
            {
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
                Audience = _jwtoptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtoptions.SigningKey)),
                    SecurityAlgorithms.HmacSha256),
                Subject = claims 
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
