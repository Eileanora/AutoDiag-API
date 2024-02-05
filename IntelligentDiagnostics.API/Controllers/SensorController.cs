using IntelligentDiagnostics.BL.Dtos.SensorDTOs;
using IntelligentDiagnostics.BL.Mapper.SensorsManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IntelligentDiagnostics.API.Controllers;

[Route("api/v1/sensors")]
[ApiController]
public class SensorController : ControllerBase
{
    private readonly ISensorsManager _sensorsManager;
    public SensorController(ISensorsManager sensorsManager)
    {
        _sensorsManager = sensorsManager;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SensorDto>>> GetSensors()
    {
        var sensors = await _sensorsManager.GetAllAsync();
        return Ok(sensors);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<SensorDto>> GetByIdAsync(int id)
    {
        var sensor = await _sensorsManager.GetByIdAsync(id);
        if (sensor == null)
        {
            return NotFound();
        }
        return Ok(sensor);
    }
    // post, patch, delete
    [HttpPost]
    public async Task<ActionResult<SensorDto> CreateSensor(
        SensorCreateDto sensor)
    {
        
    }
}
