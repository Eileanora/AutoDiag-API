using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.ReadingFacade;

public interface IReadingFacade
{
    public IReadingRepository ReadingRepository { get; }
    public IValidator<ReadingForCreationDto> CreationValidator { get; }
}