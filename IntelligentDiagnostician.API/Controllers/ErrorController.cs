using Asp.Versioning;
using IntelligentDiagnostician.API.Helpers.Facades.ErrorControllerFacade;
using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/faults")]
public class ErrorController : ControllerBase
{
    private readonly IErrorControllerFacade _errorControllerFacade;
    
    public ErrorController(IErrorControllerFacade errorControllerFacade)
    {
        _errorControllerFacade = errorControllerFacade;
    }
    
    [HttpGet(Name = "GetAllErrors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpHead]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    public async Task<ActionResult<IEnumerable<ErrorDto>>> GetAllErrorsAsync(
        [FromQuery] ErrorsResourceParameters resourceParameters)
    {
        var errors = await _errorControllerFacade.ErrorManager
            .GetAllAsync(resourceParameters);
        
        _errorControllerFacade.ErrorPaginationHelper
            .CreateMetaDataHeader(errors, resourceParameters, Response.Headers, Url);
        
        return Ok(errors);
    }
}
