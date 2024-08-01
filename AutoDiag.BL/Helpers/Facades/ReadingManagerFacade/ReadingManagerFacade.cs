using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.Repositories;
using AutoDiag.BL.Services.CurrentUserService;
using FluentValidation;

namespace AutoDiag.BL.Helpers.Facades.ReadingManagerFacade;

public class ReadingManagerFacade : IReadingManagerFacade
{
    public IReadingRepository ReadingRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
    public IValidator<ReadingForCreationDto> CreationValidator { get; }
    public ICurrentUserService CurrentUserService { get; }
    public IValidator<Guid> UserIdValidator { get; }

    public ReadingManagerFacade(
        IReadingRepository readingRepository,
        IValidator<ReadingForCreationDto> creationValidator,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService,
        IValidator<Guid> userIdValidator)
    {
        ReadingRepository = readingRepository;
        UnitOfWork = unitOfWork;
        CreationValidator = creationValidator;
        CurrentUserService = currentUserService;
        UserIdValidator = userIdValidator;
    }
}
