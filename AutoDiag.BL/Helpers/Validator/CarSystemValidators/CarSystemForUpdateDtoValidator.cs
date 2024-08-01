using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;
using FluentValidation.Validators;

namespace AutoDiag.BL.Helpers.Validator.CarSystemValidators;

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
