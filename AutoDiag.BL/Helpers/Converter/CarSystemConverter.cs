using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Helpers.Converter;

public static class CarSystemConverter
{
    public static CarSystemDto ToListDto(this CarSystem carSystem)
    {
        return new CarSystemDto
        {
            Id = carSystem.Id,
            CarSystemName = carSystem.CarSystemName
        };
    }

    public static CarSystemDto ToDto(this CarSystem carSystem)
    {
        return new CarSystemDto
        {
            Id = carSystem.Id,
            CarSystemName = carSystem.CarSystemName,
            Sensors = carSystem.Sensors.Select(s =>s.ToDto()).ToList()
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
                ? carSystemForCreation.Sensors.Select(s => s.ToEntity()).ToList() : null
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
