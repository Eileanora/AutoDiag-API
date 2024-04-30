using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.BL.Utils.Facades.FaultManagerFacade;

public interface IFaultManagerFacade
{
    public IErrorRepository ErrorRepository { get; }
    public IValidator<FaultForCreationDto> CreationValidator { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ICurrentUserService CurrentUserService { get; }
}
