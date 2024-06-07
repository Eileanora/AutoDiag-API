using FluentValidation;
using IntelligentDiagnostician.API.Helpers.PaginationHelper;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
public class CarSystemControllerControllerFacade : ICarSystemControllerFacade
{
    public ICarSystemManager CarSystemManager { get; }
    public IValidator<CarSystemForCreationDto> CreationValidator { get; }
    public IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    public IPaginationHelper<CarSystemDto, CarSystemsResourceParameters> PaginationHelper { get; }


    public CarSystemControllerControllerFacade(
        ICarSystemManager carSystemManager,
        IValidator<CarSystemForCreationDto> creationValidator,
        IValidator<CarSystemForUpdateDto> updateValidator,
        IPaginationHelper<CarSystemDto, CarSystemsResourceParameters> carSystemPaginationHelper)
    {
        CarSystemManager = carSystemManager;
        CreationValidator = creationValidator;
        UpdateValidator = updateValidator;
        PaginationHelper = carSystemPaginationHelper;
    }
}
