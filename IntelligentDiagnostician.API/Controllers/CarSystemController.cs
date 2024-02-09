using IntelligentDiagnostician.BL.Dtos.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Controllers;

[Route("api/v1/carsystems")]
[ApiController]
public class CarSystemController : ControllerBase
{
    private readonly ICarSystemManager _carSystemManager;
    public CarSystemController(ICarSystemManager carSystemManager)
    {
        _carSystemManager = carSystemManager;
    }
    [HttpGet]
    public async Task<ActionResult<CarSystemDto>> GetAllSystemsAsync()
    {
        var systems = await _carSystemManager.GetAllAsync();
        return Ok(systems);
    }
    // [HttpGet("{id}")]
    // public async Task<ActionResult> GetByIdAsync(int id, bool includeSensors = false)
    // {
    //     
    // }
    [HttpGet("{id}")]
    public async Task<ActionResult<CarSystemDtoWithSensors>> GetByIdAsync(int id)
    {
        var system = await _carSystemManager.GetByIdWithSensorsAsync(id);
        if (system == null)
        {
            return NotFound();
        }
        return Ok(system);
    }
}
