using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Helpers.Converter;

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
            MinValue = sensor.MinValue,
            AvgValue = sensor.AvgValue,
            MaxValue = sensor.MaxValue,
            Unit = sensor.Unit
        };
    }
    
    public static SensorDto ToDto(this Sensor sensor)
    {
        return new SensorDto
        {
            Id = sensor.Id,
            SensorName = sensor.SensorName,
            MinValue = sensor.MinValue,
            AvgValue = sensor.AvgValue,
            MaxValue = sensor.MaxValue,
            Unit = sensor.Unit
        };
    }
    
    public static Sensor ToEntity(this SensorForCreationDto sensorDto, int systemId)
    {
        var sensor = new Sensor
        {
            Id = sensorDto.Id,
            SensorName = sensorDto.SensorName,
            CarSystemId = systemId,
            MinValue = sensorDto.MinValue,
            MaxValue = sensorDto.MaxValue,
            AvgValue = sensorDto.AvgValue,
            Unit = sensorDto.Unit
        };

        return sensor;
    }
    public static Sensor ToEntity(this SensorForCreationDto sensorDto)
    {
        var sensor = new Sensor
        {
            Id = sensorDto.Id,
            SensorName = sensorDto.SensorName,
            MinValue = sensorDto.MinValue,
            MaxValue = sensorDto.MaxValue,
            AvgValue = sensorDto.AvgValue,
            Unit = sensorDto.Unit
        };

        return sensor;
    }
    
    public static SensorForUpdateDto ToUpdateDto(this SensorDto sensorDto, int carSystemId)
    {
        return new SensorForUpdateDto
        {
            SensorName = sensorDto.SensorName,
            CarSystemId = carSystemId,
            MinValue = sensorDto.MinValue,
            MaxValue = sensorDto.MaxValue,
            AvgValue = sensorDto.AvgValue,
            Unit = sensorDto.Unit
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
    public static Sensor ToSensorEntity(this SensorForUpdateDto sensorForUpdate, ref Sensor sensor)
    {
        sensor.SensorName = sensorForUpdate.SensorName;
        sensor.CarSystemId = sensorForUpdate.CarSystemId;
        sensor.MinValue = sensorForUpdate.MinValue;
        sensor.MaxValue = sensorForUpdate.MaxValue;
        sensor.AvgValue = sensorForUpdate.AvgValue;
        sensor.Unit = sensorForUpdate.Unit;
        return sensor;
    }
}
