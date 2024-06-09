using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Utils.Converter;

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
