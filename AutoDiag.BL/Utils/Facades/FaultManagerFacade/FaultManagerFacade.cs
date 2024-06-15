using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.Repositories;
using AutoDiag.BL.Services.CurrentUserService;
using FluentValidation;

namespace AutoDiag.BL.Utils.Facades.FaultManagerFacade;

public class FaultManagerFacade : IFaultManagerFacade
{
    public IErrorRepository ErrorRepository { get; }
    public IValidator<FaultForCreationDto> CreationValidator { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ICurrentUserService CurrentUserService { get; }
    public IValidator<Guid> UserIdValidator { get; }

    public FaultManagerFacade(
        IErrorRepository errorRepository,
        IValidator<FaultForCreationDto> creationValidator,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService,
        IValidator<Guid> userIdValidator)
    {
        ErrorRepository = errorRepository;
        CreationValidator = creationValidator;
        UnitOfWork = unitOfWork;
        CurrentUserService = currentUserService;
        UserIdValidator = userIdValidator;
    }
}
