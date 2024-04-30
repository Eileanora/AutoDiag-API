using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.BL.Utils.Facades.ErrorManagerFacade;

public class ErrorManagerFacade : IErrorManagerFacade
{
    public IErrorRepository ErrorRepository { get; }
    public IValidator<ErrorForCreationDto> CreationValidator { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ICurrentUserService CurrentUserService { get; }
    
    public ErrorManagerFacade(
        IErrorRepository errorRepository,
        IValidator<ErrorForCreationDto> creationValidator,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService)
    {
        ErrorRepository = errorRepository;
        CreationValidator = creationValidator;
        UnitOfWork = unitOfWork;
        CurrentUserService = currentUserService;
    }
}
