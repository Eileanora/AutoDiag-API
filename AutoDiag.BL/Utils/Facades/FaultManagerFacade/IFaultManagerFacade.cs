using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.Repositories;
using AutoDiag.BL.Services.CurrentUserService;
using FluentValidation;

namespace AutoDiag.BL.Utils.Facades.FaultManagerFacade;

public interface IFaultManagerFacade
{
    public IErrorRepository ErrorRepository { get; }
    public IValidator<FaultForCreationDto> CreationValidator { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ICurrentUserService CurrentUserService { get; }
    public IValidator<Guid> UserIdValidator { get; }
}
