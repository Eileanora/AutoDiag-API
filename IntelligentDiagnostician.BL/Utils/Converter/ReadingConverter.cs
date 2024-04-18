using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Converter;

public static class ReadingConverter
{
    public static Reading ToReading(this ReadingForCreationDto readingForCreationDto)
    {
        return new Reading
        {
            Value = readingForCreationDto.Value,
            SensorId = readingForCreationDto.SensorId,
            UserId = readingForCreationDto.UserId.ToString(),
        };
    }
}
