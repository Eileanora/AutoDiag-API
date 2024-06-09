using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;

namespace AutoDiag.BL.Utils.Facades.SensorManagerFacade;
public interface ISensorManagerFacade
{
     ISensorRepository SensorRepository { get; }
     IValidator<SensorForCreationDto> CreationValidator { get; }
     IValidator<SensorForUpdateDto> UpdateValidator { get; }
     IUnitOfWork UnitOfWork { get; }
    
}