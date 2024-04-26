using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.SensorManagerFacade;
public interface ISensorManagerFacade
{
     ISensorRepository SensorRepository { get; }
     IValidator<SensorForCreationDto> CreationValidator { get; }
     IValidator<SensorForUpdateDto> UpdateValidator { get; }
     IUnitOfWork UnitOfWork { get; }
    
}