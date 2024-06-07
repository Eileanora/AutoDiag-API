using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;

public interface ICarSystemControllerFacade
{
    ICarSystemManager CarSystemManager { get; }
    IValidator<CarSystemForCreationDto> CreationValidator { get; }
    IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    IPaginationHelper<CarSystemDto, CarSystemsResourceParameters> PaginationHelper { get; }
}
