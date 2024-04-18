using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.ReadingFacade;

public class ReadingFacade : IReadingFacade
{
    public IReadingRepository ReadingRepository { get; }
    public IValidator<ReadingForCreationDto> CreationValidator { get; }
    
    public ReadingFacade(
        IReadingRepository readingRepository,
        IValidator<ReadingForCreationDto> creationValidator)
    {
        ReadingRepository = readingRepository;
        CreationValidator = creationValidator;
    }
}