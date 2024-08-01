using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;

namespace AutoDiag.BL.Helpers.Facades.CarSystemManagerFacade;

public interface ICarSystemManagerFacade
{
    ICarSystemRepository CarSystemRepository { get; }
    IValidator<CarSystemForCreationDto> CreationValidator { get; }
    IValidator<CarSystemForUpdateDto> UpdateValidator { get; }
    IUnitOfWork UnitOfWork { get; }
}
