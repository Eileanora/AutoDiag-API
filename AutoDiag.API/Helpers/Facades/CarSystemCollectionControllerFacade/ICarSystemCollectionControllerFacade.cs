using FluentValidation;
using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.Manager.CarSystemManager;

namespace AutoDiag.API.Helpers.Facades.CarSystemCollectionControllerFacade;

public interface ICarSystemCollectionControllerFacade
{
     public ICarSystemManager CarSystemManager { get; }
     public IValidator<CarSystemForCreationDto> CreationValidator { get; }
}
