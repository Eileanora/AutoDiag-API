﻿using Asp.Versioning;
using AutoDiag.API.Helpers.Facades.FaultControllerFacade;
using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoDiag.API.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/faults")]
public class FaultController : ControllerBase
{
    private readonly IFaultControllerFacade _faultControllerFacade;
    
    public FaultController(IFaultControllerFacade faultControllerFacade)
    {
        _faultControllerFacade = faultControllerFacade;
    }
    
    [HttpGet(Name = "GetAllErrors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpHead]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    public async Task<ActionResult<IEnumerable<FaultDto>>> GetAllErrorsAsync(
        [FromQuery] FaultsResourceParameters resourceParameters)
    {
        var errors = await _faultControllerFacade.FaultManager
            .GetAllAsync(resourceParameters);
        
        _faultControllerFacade.PaginationHelper
            .CreateMetaDataHeader(errors, resourceParameters, Response.Headers, Url, "GetAllErrors");
        
        return Ok(errors);
    }
}
