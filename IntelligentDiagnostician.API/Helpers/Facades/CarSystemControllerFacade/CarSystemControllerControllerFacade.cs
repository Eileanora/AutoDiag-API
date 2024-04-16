using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
public class CarSystemControllerControllerFacade : ICarSystemControllerFacade
{
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<CarSystemForCreationDto> CreationValidator { get; }
    public IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    public ICarSystemPaginationHelper CarSystemPaginationHelper { get; }

    public CarSystemControllerControllerFacade(
        ICarSystemManager carSystemManager,
        IValidator<CarSystemForCreationDto> creationValidator,
        IValidator<CarSystemForUpdateDto> updateValidator,
        ICarSystemPaginationHelper carSystemPaginationHelper)
    {
        CarSystemManager = carSystemManager;
        CreationValidator = creationValidator;
        UpdateValidator = updateValidator;
        CarSystemPaginationHelper = carSystemPaginationHelper;
    }
}
