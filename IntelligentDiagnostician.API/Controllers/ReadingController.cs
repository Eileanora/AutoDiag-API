using Asp.Versioning;
using IntelligentDiagnostician.API.Helpers.Facades.ReadingControllerFacade;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/car-systems/{carSystemId}/sensors/{sensorId}/readings")]
[ApiController]
public class ReadingController : ControllerBase
{
    private readonly IReadingControllerFacade _readingControllerFacade;
    public ReadingController(IReadingControllerFacade readingControllerFacade)
    {
        _readingControllerFacade = readingControllerFacade;
    }
    
    
    [HttpGet(Name = "GetAllReadings")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    public async Task<ActionResult<PagedList<ReadingDto>>> GetAllReadings(
        int sensorId,
        [FromQuery] ReadingResourceParameters readingResourceParameters)
    {
        if (_readingControllerFacade.SensorManager.SensorExistsAsync(sensorId).Result == false)
            return NotFound();
        
        var readings = await _readingControllerFacade
            .ReadingManager
            .GetAllAsync(sensorId, readingResourceParameters);
        
        _readingControllerFacade.ReadingPaginationHelper
            .CreateMetaDataHeader(
            readings,
            readingResourceParameters,
            Response.Headers, Url);
        return Ok(readings);
    }
}
