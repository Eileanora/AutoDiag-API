using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.BL.Utils.Facades.ErrorManagerFacade;

public interface IErrorManagerFacade
{
    public IErrorRepository ErrorRepository { get; }
    public IValidator<ErrorForCreationDto> CreationValidator { get; }
    public IUnitOfWork UnitOfWork { get; }
    public ICurrentUserService CurrentUserService { get; }
}
