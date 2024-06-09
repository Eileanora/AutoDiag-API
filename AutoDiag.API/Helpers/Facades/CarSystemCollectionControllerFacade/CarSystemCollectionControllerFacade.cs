using FluentValidation;
using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.Manager.CarSystemManager;

namespace AutoDiag.API.Helpers.Facades.CarSystemCollectionControllerFacade;

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
