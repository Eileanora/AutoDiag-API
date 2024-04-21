﻿using Asp.Versioning;
using IntelligentDiagnostician.API.Helpers.InputValidator;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using IntelligentDiagnostician.BL.Utils.Converter;
using Microsoft.AspNetCore.Authorization;


namespace IntelligentDiagnostician.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/car-systems")]
[ApiController]
public class CarSystemController(ICarSystemControllerFacade carSystemControllerFacade)
    : ControllerBase
{
    [HttpHead]
    [HttpGet(Name="GetAllSystems")]
    // [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CarSystemDto>> GetAllSystemsAsync(
        [FromQuery] CarSystemsResourceParameters resourceParameters)
    {
        var systems = await carSystemControllerFacade.CarSystemManager
            .GetAllAsync(resourceParameters);
            
        carSystemControllerFacade.CarSystemPaginationHelper
            .CreateMetaDataHeader(systems, resourceParameters, Response.Headers, Url);
        
        return Ok(systems);
    }
    // [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
    [HttpGet("{systemId}", Name = "GetSystemById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]

    public async Task<ActionResult<CarSystemDto>> GetSystemByIdAsync(int systemId)
    {
        var system = await carSystemControllerFacade.CarSystemManager.GetByIdAsync(systemId);
        if (system == null)
        {
            return NotFound();
        }
        return Ok(system);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult<CarSystemDto>> CreateSystem(
        CarSystemForCreationDto systemForCreation)
    {
        var validationResult = await carSystemControllerFacade.CreationValidator.ValidateAsync(
            systemForCreation, 
            options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        
        var createdSystem = await carSystemControllerFacade.CarSystemManager.CreateAsync(systemForCreation);
        if (createdSystem == null)
            return BadRequest();
        
        return CreatedAtRoute(
            routeName: "GetSystemById",
            routeValues: new { systemId = createdSystem.Id },
            value: createdSystem);
    }
    
    [HttpPatch("{systemId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult> UpdateSystem(
        int systemId, JsonPatchDocument<CarSystemForUpdateDto> patchDocument)
    {
        var system = await carSystemControllerFacade.CarSystemManager.GetByIdAsync(systemId);
        if (system == null)
            return NotFound();
        
        var systemToPatch = system.ToUpdateDto();
        patchDocument.ApplyTo(systemToPatch, ModelState);
        
        // check if the patch was successful
        var validationResult = await carSystemControllerFacade.UpdateValidator
            .ValidateAsync(
                systemToPatch,
                options => options.IncludeRuleSets("Input"));
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }
        // if the patch was successful, update the system
        await carSystemControllerFacade.CarSystemManager.UpdateAsync(systemId, systemToPatch);
        return NoContent();
    }
    
    [HttpDelete("{systemId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public async Task<ActionResult> DeleteSystem(int systemId)
    {
        var deleted = await carSystemControllerFacade.CarSystemManager.DeleteAsync(systemId);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
    
    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSystemsOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,PATCH,DELETE,OPTIONS");
        return Ok();
    }
}
