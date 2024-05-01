using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.CarSystemManagerFacade;

public interface ICarSystemManagerFacade
{
    ICarSystemRepository CarSystemRepository { get; }
    IValidator<CarSystemForCreationDto> CreationValidator { get; }
    IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    IUnitOfWork UnitOfWork { get; }
}
