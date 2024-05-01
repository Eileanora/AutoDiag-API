using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;

namespace IntelligentDiagnostician.API.Helpers.Facades.CarSystemCollectionControllerFacade;

public interface ICarSystemCollectionControllerFacade
{
     public ICarSystemManager CarSystemManager { get; }
     public IValidator<CarSystemForCreationDto> CreationValidator { get; }
}
