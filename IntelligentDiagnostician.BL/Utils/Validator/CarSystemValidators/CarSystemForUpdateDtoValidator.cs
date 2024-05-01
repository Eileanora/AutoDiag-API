using FluentValidation;
using FluentValidation.Validators;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.CarSystemValidators;

public class CarSystemForUpdateDtoValidator : AbstractValidator<CarSystemForUpdateDto>
{
    public CarSystemForUpdateDtoValidator(ICarSystemRepository carSystemRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(x => x.CarSystemName).NameValidation();
        });
        RuleSet("Business", () =>
        {
            RuleFor(c => c)
                .MustAsync(async (c, _, context, cancellationToken) =>
                {
                    var existingSystem = await carSystemRepository.GetByNameAsync(c.CarSystemName);
                    var systemId = (int)context.RootContextData["systemId"];
                    return existingSystem == null || existingSystem.Id == systemId;
                })
                .WithMessage("CarSystemName already exists.");
        });
    }
}
