using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;



namespace IntelligentDiagnostician.API.Controllers;

[Route("api/v1/car-systems")]
[ApiController]
public class CarSystemController(ICarSystemManager carSystemManager) : ControllerBase
{
    [HttpHead]
    [HttpGet]
    public async Task<ActionResult<CarSystemDto>> GetAllSystemsAsync(
        [FromQuery] CarSystemsResourceParameters resourceParameters)
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
        
        // TODO: Review mapping and return value for routeValue
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
        
        var systemToPatch = system.ToUpdateDto();
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
    
    [HttpOptions]
    public IActionResult GetSystemsOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,PATCH,DELETE,OPTIONS");
        return Ok();
    }
}
