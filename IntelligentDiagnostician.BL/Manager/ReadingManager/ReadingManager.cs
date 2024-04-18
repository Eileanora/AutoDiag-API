using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Utils.Facades.ReadingFacade;
using FluentValidation;
using IntelligentDiagnostician.BL.Utils.Converter;

namespace IntelligentDiagnostician.BL.Manager.ReadingManager;

public class ReadingManager(IReadingFacade readingFacade) : IReadingManager
{
    public async Task CreateAsync(
        int sensorId, Guid userId, int value)
    {
        var readingForCreationDto = new ReadingForCreationDto
        {
            SensorId = sensorId,
            UserId = userId,
            Value = value
        };
        var validationResult = await readingFacade.CreationValidator.ValidateAsync(
            readingForCreationDto,
            options => options.IncludeRuleSets("Business"));
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var newReading = readingForCreationDto.ToReading();
        await readingFacade.ReadingRepository.CreateAsync(newReading);
    }
}
