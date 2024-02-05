using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostics.API.Controllers.LoginController;

[Route("api/v1/login")]
[ApiController]
public class LoginController : ControllerBase
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginModel login)
    {
        if (login.Username == "admin" && login.Password == "admin")
        {
            return Ok("Login successful");
        }
        else
        {
            return Unauthorized();
        }
    }
}
