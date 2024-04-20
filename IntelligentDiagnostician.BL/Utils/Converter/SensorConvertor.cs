using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Converter;

public static class SensorConvertor
{
    public static SensorDto ToListDto(this Sensor sensor)
    {
        if (sensor == null)
            throw new Exception("Sensor is null.");
        return new SensorDto
        {
            Id = sensor.Id,
            SensorName = sensor.SensorName,
            CreatedBy = sensor.CreatedBy ?? Guid.Empty,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = sensor.ModifiedBy ?? Guid.Empty,
            ModifiedDate = sensor.ModifiedDate
        };
    }
    
    public static SensorDto ToDto(this Sensor sensor)
    {
        return new SensorDto
        {
            Id = sensor.Id,
            SensorName = sensor.SensorName,
            // CarSystemName = sensor.CarSystem.CarSystemName,
            CreatedBy = sensor.CreatedBy ?? Guid.Empty,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = sensor.ModifiedBy ?? Guid.Empty,
            ModifiedDate = sensor.ModifiedDate
        };
    }
    
    public static Sensor ToEntity(this SensorForCreationDto sensorDto, int systemId)
    {
        return new Sensor
        {
            SensorName = sensorDto.SensorName,
            CarSystemId = systemId,
        };
    }
    
    public static SensorForUpdateDto ToUpdateDto(this SensorDto sensorDto)
    {
        return new SensorForUpdateDto
        {
            SensorName = sensorDto.SensorName,
            CarSystemId = sensorDto.CarSystemId
        };
    }
    
    public static PagedList<SensorDto> ToListDto(this PagedList<Sensor> sensors)
    {
        var count = sensors.TotalCount;
        var pageNumber = sensors.CurrentPage;
        var pageSize = sensors.PageSize;
        var totalPages = sensors.TotalPages;
        return new PagedList<SensorDto>(
            sensors.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
}
