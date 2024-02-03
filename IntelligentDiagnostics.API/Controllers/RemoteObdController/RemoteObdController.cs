using IntelligentDiagnostics.BL.Dtos.FaultsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostics.API.Controllers.RemoteObdController;

[ApiController]
[Route("api/remote-obd")]
public class RemoteObdController : ControllerBase
{
    [HttpGet]
    public ActionResult<FaultsDto> GetCurrentFaults()
    {
        return Ok();
    }
}
