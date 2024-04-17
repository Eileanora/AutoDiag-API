using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using Microsoft.AspNetCore.Authorization;
﻿using Asp.Versioning;
using IntelligentDiagnostician.API.Helpers.InputValidator;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.BL.Utils.Converter;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/car-systems/{systemId}/sensors")]
[ApiController]
public class SensorController(ISensorControllerFacade sensorControllerFacade) : ControllerBase
{
    [HttpHead]
    [HttpGet(Name = "GetAllSensors")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SensorDto>> GetSensors(
        int systemId, 
        [FromQuery] SensorsResourceParameters resourceParameters)
    {
        if(sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensors = await sensorControllerFacade
            .SensorsManager
            .GetAllAsync(systemId, resourceParameters);

        sensorControllerFacade.SensorPaginationHelper
            .CreateMetaDataHeader(
                sensors,
                resourceParameters,
                Response.Headers, Url);
        
        return Ok(sensors);
    }
    [HttpGet("{sensorId}", Name = "GetSensorById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SensorDto>> GetByIdAsync(int systemId, int sensorId)
    {
        if(sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await sensorControllerFacade.SensorsManager.GetByIdAsync(sensorId);
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
        if (sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();

        var validationResult = await sensorControllerFacade.CreationValidator
            .ValidateAsync(sensor,
                options => options.IncludeRuleSets("Input"));
        
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(this.ModelState);
            return ValidationProblem(ModelState);
        }

        var newSensor = await sensorControllerFacade.SensorsManager.CreateAsync(systemId, sensor);
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
        if(sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        
        var sensor = await sensorControllerFacade.SensorsManager.GetByIdAsync(sensorId);
        if (sensor == null)
            return NotFound();
        
        var sensorToPatch = sensor.ToUpdateDto();
        patchDocument.ApplyTo(sensorToPatch, ModelState);
        
        // check if the patch was successful
        var validationResult = await sensorControllerFacade.UpdateValidator.ValidateAsync(
            sensorToPatch,
            options => options.IncludeRuleSets("Input"));
        if (!validationResult.IsValid)
            validationResult.AddToModelState(this.ModelState);

        if (!TryValidateModel(ModelState))
            return ValidationProblem(ModelState);
         
        await sensorControllerFacade.SensorsManager.UpdateAsync(sensorId, sensorToPatch);
        return NoContent();
    }
    
    [HttpDelete("{sensorId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteSensor(int systemId, int sensorId)
    {
        if(sensorControllerFacade.CarSystemManager.CarSystemExistsAsync(systemId).Result == false)
            return NotFound();
        var sensorToDelete = await sensorControllerFacade.SensorsManager.GetByIdAsync(sensorId);
        
        if (sensorToDelete == null)
            return NotFound();
        
        await sensorControllerFacade.SensorsManager.DeleteAsync(sensorToDelete);
        
        return NoContent();
    }
    [Route("/api/v{version:apiVersion}/car-systems/sensors")]
    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSensorsOptions()
    {
        Response.Headers.Append("Allow", "GET,POST,PATCH,DELETE,OPTIONS");
        return Ok();
    }
}
