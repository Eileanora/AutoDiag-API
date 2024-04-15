using System.Text.Json.Nodes;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace IntelligentDiagnostician.API.Controllers;

[Route("api/v1/car-systems")]
[ApiController]
public class CarSystemController(ICarSystemManager carSystemManager) : ControllerBase
{


    [Authorize(AuthenticationSchemes = "Bearer" , Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<CarSystemDto>> GetAllSystemsAsync()
    {
        var systems = await carSystemManager.GetAllAsync();
        return Ok(systems);
    }

    [HttpGet("{systemId}", Name = "GetSystemById")]
    public async Task<ActionResult<CarSystemDto>> GetSystemByIdAsync(int systemId)
    {
        var system = await carSystemManager.GetByIdAsync(systemId);
        if (system == null)
        {
            return NotFound();
        }
        return Ok(system);
    }
    
    [HttpPost]
    public async Task<ActionResult<CarSystemDto>> CreateSystem(
        CarSystemForCreationDto systemFor)
    {
        var createdSystem = await carSystemManager.CreateAsync(systemFor);
        if(createdSystem == null)
            return BadRequest();
        return CreatedAtRoute(
            routeName: "GetSystemById",
            routeValues: new { systemId = createdSystem.Id },
            value: createdSystem);
    }
    
    [HttpPatch("{systemId}")]
    public async Task<ActionResult> UpdateSystem(
        int systemId, JsonPatchDocument<CarSystemForUpdateDto> patchDocument)
    {
        var system = await carSystemManager.GetByIdAsync(systemId);
        if (system == null)
            return NotFound();
        
        var systemToPatch = new CarSystemForUpdateDto
        {
            Name = system.Name
        };
        patchDocument.ApplyTo(systemToPatch, ModelState);
        // check if the patch was successful
        if (!TryValidateModel(systemToPatch))
            return ValidationProblem(ModelState);
        // if the patch was successful, update the system
        await carSystemManager.UpdateAsync(systemId, systemToPatch);
        return NoContent();
    }
    
    [HttpDelete("{systemId}")]
    public async Task<ActionResult> DeleteSystem(int systemId)
    {
        var deleted = await carSystemManager.DeleteAsync(systemId);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
