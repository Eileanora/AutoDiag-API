using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Mapper.Converter;

public static class CarSystemConverter
{
    public static CarSystemDto ToListDto(this CarSystem carSystem)
    {
        return new CarSystemDto
        {
            Id = carSystem.Id,
            CarSystemName = carSystem.CarSystemName,
            CreatedBy = 1,
            CreatedDate = carSystem.CreatedDate,
            ModifiedBy = 1,
            ModifiedDate = carSystem.ModifiedDate
        };
    }

    public static CarSystemDto ToDto(this CarSystem carSystem)
    {
        return new CarSystemDto
        {
            Id = carSystem.Id,
            CarSystemName = carSystem.CarSystemName,
            CreatedBy = 1,
            CreatedDate = carSystem.CreatedDate,
            ModifiedBy = 1,
            ModifiedDate = carSystem.ModifiedDate,
            Sensors = carSystem.Sensors.Select(s => new SensorDto
            {
                Id = s.Id,
                SensorName = s.SensorName
            }).ToList()
        };
    }
    
    public static CarSystemForUpdateDto ToUpdateDto(this CarSystemDto carSystemDto)
    {
        return new CarSystemForUpdateDto
        {
            CarSystemName = carSystemDto.CarSystemName
        };
    }
    
    public static CarSystem ToEntity(this CarSystemForCreationDto carSystemForCreation)
    {
        return new CarSystem
        {
            CarSystemName = carSystemForCreation.CarSystemName,
            Sensors = carSystemForCreation.Sensors != null
                ? carSystemForCreation.Sensors
                    .Select(s => new Sensor { SensorName = s.SensorName }).ToList()
                : null
        };
    }
    
    public static void UpdateEntity(this CarSystemForUpdateDto carSystemForUpdate, CarSystem carSystem)
    {
        carSystem.CarSystemName = carSystemForUpdate.CarSystemName;
    }
}
