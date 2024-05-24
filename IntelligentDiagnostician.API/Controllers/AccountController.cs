using IntelligentDiagnostician.BL.AuthServices;
using IntelligentDiagnostician.BL.DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace IntelligentDiagnostician.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;  
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAync(CreateUserDto createuserdto) 
        {
            if(!ModelState.IsValid) 
                return ValidationProblem(ModelState);

            var result = await _authService.RegisterAsync(createuserdto); 
            
            if( result.IsAuthenticated is not true ) 
                return BadRequest(result.Message);

            return Ok( new
            {
                result.Id,
                result.Email,
                result.UserName,
                result.Token,
                result.Roles , 
            }); 
        }

        [HttpPost("LogInUser")]
        public async Task<IActionResult> Login(LoginUser loginuser) 
        {
            if(!ModelState.IsValid) 
                return ValidationProblem(ModelState);

            var result = await _authService.LoginAsync(loginuser);  

            if(result.IsAuthenticated is not true ) 
                return BadRequest(result.Message);

            return Ok( new
            {
                result.Id,
                result.Email,
                result.Token,
                result.Roles
            });
        }

        [HttpPost("AssignRolesToUser")]
    //    [Authorize(AuthenticationSchemes = "Bearer", Roles = "SuperUser")]

        public async Task<IActionResult> AssignRolesToUser(AssignRolesToUser assignRolesToUser)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var result = await _authService.AssignRolesToUser(assignRolesToUser);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(assignRolesToUser);
        }
        [HttpPost("ChangePassword")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]

        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.ChangePassword(changePassword);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result.Message);

        }



    }
}
