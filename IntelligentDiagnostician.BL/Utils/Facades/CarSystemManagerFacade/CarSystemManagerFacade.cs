using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Facades.CarSystemManagerFacade;
public class CarSystemManagerFacade : ICarSystemManagerFacade
{
    public ICarSystemRepository CarSystemRepository { get; }
    public IValidator<CarSystemForCreationDto> CreationValidator { get; }
    public IValidator<CarSystemForUpdateDto> UpdateValidator { get; }

    public CarSystemManagerFacade(
        ICarSystemRepository carSystemRepository,
        IValidator<CarSystemForCreationDto> creationValidator,
        IValidator<CarSystemForUpdateDto> updateValidator)
    {
        CarSystemRepository = carSystemRepository;
        CreationValidator = creationValidator;
        UpdateValidator = updateValidator;
    }
}
