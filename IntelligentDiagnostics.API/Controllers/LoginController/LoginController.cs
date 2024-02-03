using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostics.API.Controllers.LoginController;

[Route("api/v1/login")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost("login")]
    public ActionResult Login(
        [FromBody] string username, [FromBody] string password)
    {
        if (username == "admin" && password == "admin")
        {
            return Ok("Login successful");
        }
        else
        {
            return Unauthorized();
        }
    }
    
}
