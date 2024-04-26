using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
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
    
    public static ReadingDto ToListDto(this Reading reading)
    {
        if (reading == null)
            throw new Exception("Reading is null.");
        return new ReadingDto
        {
            Id = reading.Id,
            Value = reading.Value,
            MinValue = reading.Sensor.MinValue,
            MaxValue = reading.Sensor.MaxValue,
            AvgValue = reading.Sensor.AvgValue,
            ProblemCode = reading.TroubleCode?.ProblemCode,
            ProblemDescription = reading.TroubleCode?.ProblemDescription,
            CreatedDate = reading.CreatedDate
        };
    }
    
    public static PagedList<ReadingDto> ToListDto(this PagedList<Reading> readings)
    {
        var count = readings.TotalCount;
        var pageNumber = readings.CurrentPage;
        var pageSize = readings.PageSize;
        var totalPages = readings.TotalPages;
        return new PagedList<ReadingDto>(
            readings.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
    
}
