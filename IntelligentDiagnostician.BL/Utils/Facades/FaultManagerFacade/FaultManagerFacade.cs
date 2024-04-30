using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.BL.Utils.Facades.FaultManagerFacade;

public class FaultManagerFacade : IFaultManagerFacade
{
    public IErrorRepository ErrorRepository { get; }
    public IValidator<FaultForCreationDto> CreationValidator { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ICurrentUserService CurrentUserService { get; }
    
    public FaultManagerFacade(
        IErrorRepository errorRepository,
        IValidator<FaultForCreationDto> creationValidator,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService)
    {
        ErrorRepository = errorRepository;
        CreationValidator = creationValidator;
        UnitOfWork = unitOfWork;
        CurrentUserService = currentUserService;
    }
}
