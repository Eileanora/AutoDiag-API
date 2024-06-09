using AutoDiag.API.Helpers.PaginationHelper;
using FluentValidation;
using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.Manager.CarSystemManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.CarSystemControllerFacade;
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
