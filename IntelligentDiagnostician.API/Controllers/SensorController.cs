using IntelligentDiagnostician.API.Helpers.InputValidator;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace IntelligentDiagnostician.API.Controllers;

[Route("api/v1/car-systems/{systemId}/sensors")]
[ApiController]
public class SensorController : ControllerBase
{
    private readonly ISensorControllerFacade _sensorControllerFacade;
    public SensorController(ISensorControllerFacade sensorControllerFacade)
    {
        _sensorControllerFacade = sensorControllerFacade;
    }
    
    [HttpHead]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SensorDto>>> GetSensors(int systemId)
    {
        if(_sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensors = await _sensorControllerFacade.SensorsManager.GetAllAsync(systemId);
        return Ok(sensors);
    }

    [HttpGet("{sensorId}", Name = "GetSensorById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SensorDto>> GetByIdAsync(int systemId, int sensorId)
    {
        if(_sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await _sensorControllerFacade.SensorsManager.GetByIdAsync(sensorId);
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
        if (_sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();

        var validationResult = await _sensorControllerFacade.CreationValidator
            .ValidateAsync(sensor,
                options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }

        var newSensor = await _sensorControllerFacade.SensorsManager.CreateAsync(systemId, sensor);
        if (newSensor == null)
            return BadRequest();
        
        return CreatedAtRoute(
            routeName: "GetSensorById",
            routeValues: new { systemId = systemId, sensorId = newSensor.Id},
            value: newSensor);
    }
    
    [HttpPatch("{sensorId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateSensor(int systemId, int sensorId, JsonPatchDocument<SensorForUpdateDto> patchDocument)
    {
        if(_sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await _sensorControllerFacade.SensorsManager.GetByIdAsync(sensorId);
        if (sensor == null)
            return NotFound();
        
        var sensorToPatch = sensor.ToUpdateDto();
        patchDocument.ApplyTo(sensorToPatch, ModelState);
        
        // check if the patch was successful
        var validationResult = await _sensorControllerFacade.UpdateValidator.ValidateAsync(sensorToPatch);
        if (!validationResult.IsValid)
            validationResult.AddToModelState(this.ModelState);

        if (!TryValidateModel(ModelState))
            return ValidationProblem(ModelState);
         
        await _sensorControllerFacade.SensorsManager.UpdateAsync(sensorId, sensorToPatch);
        return NoContent();
    }
    
    [HttpDelete("{sensorId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteSensor(int systemId, int sensorId)
    {
        if(_sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        var sensorToDelete = await _sensorControllerFacade.SensorsManager.GetByIdAsync(sensorId);
        
        if (sensorToDelete == null)
            return NotFound();
        
        await _sensorControllerFacade.SensorsManager.DeleteAsync(sensorToDelete);
        
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
