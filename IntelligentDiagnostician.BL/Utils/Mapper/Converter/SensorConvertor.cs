using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Mapper.Converter;

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
            CreatedBy = 1,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = 1,
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
            CreatedBy = 1,
            CreatedDate = sensor.CreatedDate,
            ModifiedBy = 1,
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
}
