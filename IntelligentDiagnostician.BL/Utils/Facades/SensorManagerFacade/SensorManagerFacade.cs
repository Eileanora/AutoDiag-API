using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;

public class SensorManagerFacade : ISensorManagerFacade
{
    public ISensorRepository SensorRepository { get; }
    public IValidator<SensorForCreationDto> CreationValidator { get; }
    public IValidator<SensorForUpdateDto> UpdateValidator { get; }
    public IUnitOfWork UnitOfWork { get; }

    public SensorManagerFacade(
        ISensorRepository sensorRepository,
        IValidator<SensorForCreationDto> creationValidator,
        IValidator<SensorForUpdateDto> updateValidator,
        IUnitOfWork unitOfWork)
    {
        SensorRepository = sensorRepository;
        CreationValidator = creationValidator;
        UpdateValidator = updateValidator;
        UnitOfWork = unitOfWork;
    }
    
}
