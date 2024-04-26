using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper.CarSystemPaginationHelper;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;

public interface ICarSystemControllerFacade
{
    ICarSystemManager CarSystemManager { get; }
    IValidator<CarSystemForCreationDto> CreationValidator { get; }
    IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    ICarSystemPaginationHelper CarSystemPaginationHelper { get; }

    
}