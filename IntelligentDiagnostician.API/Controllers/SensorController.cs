using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
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
    
    [HttpHead]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SensorDto>>> GetSensors(int systemId)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensors = await _sensorsManager.GetAllAsync(systemId);
        return Ok(sensors);
    }

    [HttpGet("{sensorId}", Name = "GetSensorById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SensorDto>> GetByIdAsync(int systemId, int sensorId)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await _sensorsManager.GetByIdAsync(sensorId);
        if (sensor == null)
            return NotFound();
        return Ok(sensor);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<SensorDto>> CreateSensor(int systemId, SensorForCreationDto sensor)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var newSensor = await _sensorsManager.CreateAsync(systemId, sensor);
        if (newSensor == null)
            return BadRequest();
        
        // TODO: Review mapping and return value for routeValue
        return CreatedAtRoute(
            routeName: "GetSensorById",
            routeValues: new { systemId = systemId, sensorId = newSensor.Id},
            value: newSensor);
    }
    
    [HttpPatch("{sensorId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateSensor(int systemId, int sensorId, JsonPatchDocument<SensorForUpdateDto> patchDocument)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await _sensorsManager.GetByIdAsync(sensorId);
        if (sensor == null)
            return NotFound();
        
        var sensorToPatch = sensor.ToUpdateDto();
        patchDocument.ApplyTo(sensorToPatch, ModelState);
        if (!TryValidateModel(sensorToPatch))
            return ValidationProblem(ModelState);
        
        await _sensorsManager.UpdateAsync(sensorId, sensorToPatch);
        return NoContent();
    }
    
    [HttpDelete("{sensorId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteSensor(int systemId, int sensorId)
    {
        if(_carSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        var sensorToDelete = await _sensorsManager.GetByIdAsync(sensorId);
        
        if (sensorToDelete == null)
            return NotFound();
        
        await _sensorsManager.DeleteAsync(sensorToDelete);
        
        return NoContent();
    }
    [Route("/api/v1/car-systems/sensors")]
    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSensorsOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,PATCH,DELETE,OPTIONS");
        return Ok();
    }
}
