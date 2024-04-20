using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Converter;

public static class CarSystemConverter
{
    public static CarSystemDto ToListDto(this CarSystem carSystem)
    {
        return new CarSystemDto
        {
            Id = carSystem.Id,
            CarSystemName = carSystem.CarSystemName,
            CreatedBy = carSystem.CreatedBy ?? Guid.Empty,
            CreatedDate = carSystem.CreatedDate,
            ModifiedBy = carSystem.ModifiedBy ?? Guid.Empty,
            ModifiedDate = carSystem.ModifiedDate
        };
    }

    public static CarSystemDto ToDto(this CarSystem carSystem)
    {
        return new CarSystemDto
        {
            Id = carSystem.Id,
            CarSystemName = carSystem.CarSystemName,
            CreatedBy = carSystem.CreatedBy ?? Guid.Empty,
            CreatedDate = carSystem.CreatedDate,
            ModifiedBy = carSystem.ModifiedBy ?? Guid.Empty,
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
    
    // from carsystem paged list to carsystemdtolist paged list
    public static PagedList<CarSystemDto> ToListDto(this PagedList<CarSystem> carSystems)
    {
        var count = carSystems.TotalCount;
        var pageNumber = carSystems.CurrentPage;
        var pageSize = carSystems.PageSize;
        var totalPages = carSystems.TotalPages;
        return new PagedList<CarSystemDto>(
            carSystems.Select(s => s.ToListDto()).ToList(),
            count,
            pageNumber,
            pageSize,
            totalPages
        );
    }
}
