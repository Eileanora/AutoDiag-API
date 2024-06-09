using AutoDiag.BL.DTOs.CarSystemsDTOs;
using FluentValidation;

namespace AutoDiag.BL.Utils.Validator.CarSystemValidators;

public class CarSystemCollectionForCreationValidator : AbstractValidator<List<CarSystemForCreationDto>>
{
    public CarSystemCollectionForCreationValidator(
        IValidator<CarSystemForCreationDto> carSystemValidator)
    {

        RuleForEach(x => x)
            .SetValidator(carSystemValidator, ruleSets: "Input");
        
        RuleFor(x => x)
            .Must(carSystems => carSystems
                .GroupBy(c => c.CarSystemName
                    .Trim()
                    .ToLowerInvariant())
                .All(g => g
                    .Count() == 1))
            .WithMessage("Car systems must have unique names.");
    }
}
