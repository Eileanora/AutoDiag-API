using IntelligentDiagnostician.BL.AuthServices;
using IntelligentDiagnostician.BL.DTOs.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQTTnet.Formatter;

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
                return BadRequest(ModelState);

            var Result = await _authService.RegisterAsync(createuserdto); 
            
            if( Result.IsAuthenticated is not true ) 
                return BadRequest(Result.Message);

            return Ok( new
            {
                Result.Email,
                Result.UserName,
                Result.Token,
                Result.Roles , 
            }); 
        }

        [HttpPost("LogInUser")]
        public async Task<IActionResult> Login(LoginUser loginuser) 
        {
            if(!ModelState.IsValid) 
            return BadRequest(ModelState);

            var Result = await _authService.LoginAsync(loginuser);  

            if(Result.IsAuthenticated is not true ) 
                return BadRequest(Result.Message);

            return Ok( new
            {
                Result.Email,
                Result.Token,
                Result.Roles
            });
        }

        [HttpPost("AssignRolesToUser")]
        public async Task<IActionResult> AssignRolesToUser(AssignRolesToUser assignRolesToUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Result = await _authService.AssignRolesToUser(assignRolesToUser);

            if (!string.IsNullOrEmpty(Result))
                return BadRequest(Result);

            return Ok(assignRolesToUser);
        }


    }
}
