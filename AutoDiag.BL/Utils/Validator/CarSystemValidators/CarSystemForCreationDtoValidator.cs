using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.DTOs.SensorDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;

namespace AutoDiag.BL.Utils.Validator.CarSystemValidators;

public class CarSystemDtoForCreationDtoValidator : AbstractValidator<CarSystemForCreationDto>
{
    public CarSystemDtoForCreationDtoValidator(
        IValidator<SensorForCreationDto> sensorValidator,
        ICarSystemRepository carSystemRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(x => x.CarSystemName).NameValidation();
            RuleForEach(x => x.Sensors)
                .SetValidator(sensorValidator, ruleSets: "Input");
        });

        RuleSet("Business", () =>
        {
            RuleFor(c => c.CarSystemName)
                .MustAsync(async (name, _) => !await carSystemRepository.IsNameUnique(name))
                .WithMessage("Car system with this name already exists.");

            RuleFor(c => c.Sensors)
                .Must(sensors => sensors.GroupBy(s => s.SensorName.Trim().ToLowerInvariant()).All(g => g.Count() == 1))
                .WithMessage("Sensors must have unique names.");

        });
    }
}
