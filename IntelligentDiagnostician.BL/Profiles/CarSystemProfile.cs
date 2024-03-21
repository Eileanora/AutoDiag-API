using AutoMapper;
namespace IntelligentDiagnostician.BL.Profiles;

public class CarSystemProfile : Profile
{
    public CarSystemProfile()
    {
        CreateMap<DataModels.Models.CarSystem, DTOs.CarSystemsDTOs.CarSystemDto>();
        CreateMap<DTOs.CarSystemsDTOs.CarSystemForCreationDto, DataModels.Models.CarSystem>();
        CreateMap<DTOs.CarSystemsDTOs.CarSystemForUpdateDto, DataModels.Models.CarSystem>();
    }
}