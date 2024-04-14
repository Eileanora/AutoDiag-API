using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;

public class SensorManagerFacade : ISensorManagerFacade
{
    public ISensorRepository SensorRepository { get; }
    public IValidator<SensorForCreationDto> CreationValidator { get; }

    public SensorManagerFacade(
        ISensorRepository sensorRepository,
        IValidator<SensorForCreationDto> creationValidator)
    {
        SensorRepository = sensorRepository;
        CreationValidator = creationValidator;
    }
    
}
