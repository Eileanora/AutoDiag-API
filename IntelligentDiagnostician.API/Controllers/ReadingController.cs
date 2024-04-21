using Asp.Versioning;
using IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/readings")]
[ApiController]
public class ReadingController : ControllerBase
{
    private readonly IReadingControllerFacade _readingControllerFacade;
    ReadingController(IReadingControllerFacade readingControllerFacade)
    {
        _readingControllerFacade = readingControllerFacade;
    }
    
    // [HttpGet(Name = "GetAllReadings")]
    // public async Task<ActionResult<PagedList<ReadingDto>
}
