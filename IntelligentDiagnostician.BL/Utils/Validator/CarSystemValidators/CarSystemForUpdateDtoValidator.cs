using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.CarSystemValidators;

public class CarSystemForUpdateDtoValidator : AbstractValidator<CarSystemForUpdateDto>
{
    public CarSystemForUpdateDtoValidator(
        ICarSystemRepository carSystemRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(x => x.CarSystemName).NameValidation();
        });
        // TODO: Implement the business rules
        // RuleSet("Business", () =>
        // {
        //     RuleFor(c => c)
        //         .MustAsync(async (dto, _) => !await carSystemRepository.IsNameUniqueAsync(dto.))
        // });   
    }
}
