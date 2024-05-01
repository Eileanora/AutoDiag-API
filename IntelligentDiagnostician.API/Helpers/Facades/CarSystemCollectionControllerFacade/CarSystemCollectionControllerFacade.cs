using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;

public class CarSystemCollectionControllerFacade : ICarSystemCollectionControllerFacade
{
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<CarSystemForCreationDto> CreationValidator { get; }

    public CarSystemCollectionControllerFacade(
        ICarSystemManager carSystemManager,
        IValidator<CarSystemForCreationDto> creationValidator)
    {
        CarSystemManager = carSystemManager;
        CreationValidator = creationValidator;
    }
}
