using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.Repositories;
using AutoDiag.BL.Services.CurrentUserService;
using FluentValidation;

namespace AutoDiag.BL.Utils.Facades.ReadingManagerFacade;

public interface IReadingManagerFacade
{
    public IReadingRepository ReadingRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
    public IValidator<ReadingForCreationDto> CreationValidator { get; }
    public ICurrentUserService CurrentUserService { get; }
    public IValidator<Guid> UserIdValidator { get; }
}