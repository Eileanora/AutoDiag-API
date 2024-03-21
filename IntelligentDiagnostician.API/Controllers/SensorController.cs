using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentDiagnostician.API.Controllers;

[Route("api/v1/car-systems/{systemId}/sensors")]
[ApiController]
public class SensorController : ControllerBase
{
    private readonly ISensorsManager _sensorsManager;
    private readonly ICarSystemManager _carSystemManager;
    public SensorController(ISensorsManager sensorsManager, ICarSystemManager carSystemManager)
    {
        _sensorsManager = sensorsManager;
        _carSystemManager = carSystemManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SensorDto>>> GetSensors(int systemId)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensors = await _sensorsManager.GetAllAsync(systemId);
        return Ok(sensors);
    }

    [HttpGet("{sensorId}", Name = "GetSensorById")]
    public async Task<ActionResult<SensorDto>> GetByIdAsync(int systemId, int sensorId)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await _sensorsManager.GetByIdAsync(systemId, sensorId);
        if (sensor == null)
            return NotFound();
        return Ok(sensor);
    }
    [HttpPost]
    public async Task<ActionResult<SensorDto>> CreateSensor(int systemId, SensorForCreationDto sensor)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var newSensor = await _sensorsManager.CreateAsync(systemId, sensor);
        if (newSensor == null)
            return BadRequest();
        
        return CreatedAtRoute(
            routeName: "GetSensorById",
            routeValues: new { systemId = systemId, sensorId = newSensor.Id},
            value: newSensor);
    }
    
    [HttpPatch("{sensorId}")]
    public async Task<ActionResult> UpdateSensor(int systemId, int sensorId, JsonPatchDocument<SensorForUpdateDto> patchDocument)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await _sensorsManager.GetByIdAsync(systemId, sensorId);
        if (sensor == null)
            return NotFound();
        
        var sensorToPatch = new SensorForUpdateDto
        {
            SensorName = sensor.SensorName,
            CarSystemId = systemId
        };
        patchDocument.ApplyTo(sensorToPatch, ModelState);
        if (!TryValidateModel(sensorToPatch))
            return ValidationProblem(ModelState);
        
        await _sensorsManager.UpdateAsync(sensorId, sensorToPatch);
        return NoContent();
    }
    
    [HttpDelete("{sensorId}")]
    public async Task<ActionResult> DeleteSensor(int systemId, int sensorId)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var deleted = await _sensorsManager.DeleteAsync(sensorId);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
