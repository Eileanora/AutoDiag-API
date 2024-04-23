using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.Services.CurrentUserService;

namespace IntelligentDiagnostician.BL.Utils.Facades.ReadingManagerFacade;

public interface IReadingManagerFacade
{
    public IReadingRepository ReadingRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
    public IValidator<ReadingForCreationDto> CreationValidator { get; }
    public ICurrentUserService CurrentUserService { get; }
}