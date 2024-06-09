using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;

namespace AutoDiag.BL.Utils.Facades.SensorManagerFacade;

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
