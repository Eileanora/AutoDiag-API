using AutoDiag.API.Helpers.PaginationHelper;
using FluentValidation;
using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.Manager.CarSystemManager;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.API.Helpers.Facades.CarSystemControllerFacade;

public interface ICarSystemControllerFacade
{
    ICarSystemManager CarSystemManager { get; }
    IValidator<CarSystemForCreationDto> CreationValidator { get; }
    IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    IPaginationHelper<CarSystemDto, CarSystemsResourceParameters> PaginationHelper { get; }
}
