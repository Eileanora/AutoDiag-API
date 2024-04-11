using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
using IntelligentDiagnostician.DataModels.Models;


namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public class SensorsManager(ISensorManagerFacade sensorManagerFacade) : ISensorsManager
{
    
    public async Task<IEnumerable<SensorDto>> GetAllAsync(
        int systemId,
        SensorsResourceParameters resourceParameters)
    {
        var sensors = await sensorManagerFacade
            .SensorRepository
            .GetAllAsync(systemId, resourceParameters);
        return sensors.Select(s => s.ToListDto());
    }
    
    public async Task<SensorDto?> GetByIdAsync(int sensorId)
    {
        var sensor = await sensorManagerFacade.SensorRepository.GetByIdAsync(sensorId);
        if (sensor == null)
            return null;
        
        return sensor.ToDto();
    }

    public async Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor)
    {
        var validationResult = await sensorManagerFacade.CreationValidator.ValidateAsync(
            sensor,
            options => options.IncludeRuleSets("Business"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var newSensor = await sensorManagerFacade.SensorRepository.CreateAsync(sensor.ToEntity(systemId));
        if (newSensor == null)
            return null;
        
        return newSensor.ToDto();
    }

    public async Task DeleteAsync(SensorDto sensorToDelete)
    {
        var sensor = await sensorManagerFacade.SensorRepository.GetByIdAsync(sensorToDelete.Id);
        await sensorManagerFacade.SensorRepository.DeleteAsync(sensor); // ignore null here
    }
    
    
    public async Task UpdateAsync(int sensorId, SensorForUpdateDto sensorForUpdate)
    {
        // TODO: Implement business validation rules for update operation
        var sensor = await sensorManagerFacade.SensorRepository.GetByIdAsync(sensorId);
        sensor.SensorName = sensorForUpdate.SensorName;
        sensor.CarSystemId = sensorForUpdate.CarSystemId;
        await sensorManagerFacade.SensorRepository.UpdateAsync(sensor);
    }
}
