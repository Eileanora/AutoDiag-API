using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using Microsoft.AspNetCore.Mvc;


namespace IntelligentDiagnostician.API.Controllers;

[Route("api/v1/car-systems")]
[ApiController]
public class CarSystemController(ICarSystemManager carSystemManager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CarSystemDto>> GetAllSystemsAsync()
    {
        var systems = await carSystemManager.GetAllAsync();
        return Ok(systems);
    }
    // [HttpGet("{id}")]
    // public async Task<ActionResult> GetByIdAsync(int id, bool includeSensors = false)
    // {
    //     
    // }
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
    
    [HttpDelete("{systemId}")]
    public async Task<ActionResult> DeleteSystem(int systemId)
    {
        var deleted = await carSystemManager.DeleteAsync(systemId);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
