using AutoMapper;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Profiles;

public class CarSystemProfile : Profile
{
    public CarSystemProfile()
    {
        CreateMap<CarSystem, CarSystemDto>()
            .ForMember(
                dest => dest.Sensors,
                opt => opt.MapFrom(src => src.Sensors.Select(s => s.SensorName))
            );
        CreateMap<CarSystemForCreationDto, CarSystem>();
        CreateMap<CarSystemForUpdateDto, CarSystem>();
    }
}
