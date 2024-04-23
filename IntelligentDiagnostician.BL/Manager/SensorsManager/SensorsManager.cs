using FluentValidation;
using FluentValidation.Internal;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;
using IntelligentDiagnostician.BL.Utils.Converter;


namespace IntelligentDiagnostician.BL.Manager.SensorsManager;

public class SensorsManager : ISensorsManager
{
    private readonly ISensorManagerFacade _sensorManagerFacade;
    public SensorsManager(ISensorManagerFacade sensorManagerFacade)
    {
        _sensorManagerFacade = sensorManagerFacade;
    }
    public async Task<PagedList<SensorDto>> GetAllAsync(
        int systemId,
        SensorsResourceParameters resourceParameters)
    {
        var sensors = await _sensorManagerFacade
            .SensorRepository
            .GetAllAsync(systemId, resourceParameters);
        return sensors.ToListDto();
    }
    
    public async Task<SensorDto?> GetByIdAsync(int sensorId)
    {
        var sensor = await _sensorManagerFacade.SensorRepository.GetByIdAsync(sensorId);
        if (sensor == null)
            return null;
        
        return sensor.ToDto();
    }

    public async Task<SensorDto?> CreateAsync(int systemId, SensorForCreationDto sensor)
    {
        sensor.CarSystemId = systemId;
        var validationResult = await _sensorManagerFacade.CreationValidator.ValidateAsync(
            sensor,
            options => options.IncludeRuleSets("Business"));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var newSensor = await _sensorManagerFacade.SensorRepository.CreateAsync(sensor.ToEntity(systemId));
        if (newSensor == null)
            return null;
        await _sensorManagerFacade.UnitOfWork.SaveAsync();
        return newSensor.ToDto();
    }

    public async Task DeleteAsync(SensorDto sensorToDelete)
    {
        var sensor = await _sensorManagerFacade.SensorRepository.GetByIdAsync(sensorToDelete.Id);
         _sensorManagerFacade.SensorRepository.Delete(sensor); // ignore null here
         await _sensorManagerFacade.UnitOfWork.SaveAsync();
    }
    
    
    public async Task UpdateAsync(int sensorId, SensorForUpdateDto sensorForUpdate)
    {
        var context= new ValidationContext<SensorForUpdateDto>(
            sensorForUpdate,
            new PropertyChain(),
            new RulesetValidatorSelector(new [] {"Business"}))
        {
            RootContextData =
            {
                ["sensorId"] = sensorId
            }
        };

        var validationResult = await _sensorManagerFacade.UpdateValidator.ValidateAsync(context);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var sensor = await _sensorManagerFacade.SensorRepository.GetByIdAsync(sensorId);
        sensorForUpdate.ToSensorEntity(ref sensor);
        _sensorManagerFacade.SensorRepository.Update(sensor);
        await _sensorManagerFacade.UnitOfWork.SaveAsync();
    }
    
    public async Task<bool> SensorExistsAsync(int sensorId)
    {
        return await _sensorManagerFacade.SensorRepository.SensorExistsAsync(sensorId);
    }
}
