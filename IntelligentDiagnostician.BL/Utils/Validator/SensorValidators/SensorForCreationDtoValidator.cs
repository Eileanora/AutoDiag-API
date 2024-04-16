using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.SensorValidators;

public class SensorForCreationDtoValidator : AbstractValidator<SensorForCreationDto>
{
    public SensorForCreationDtoValidator(
        ISensorRepository sensorRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(s => s.SensorName).NameValidation();
        });
        RuleSet("Business", () =>
        {
            RuleFor(s => s)
                .MustAsync(async (s, _)
                    => !await sensorRepository.IsNameUniqueAsync(s.CarSystemId, s.SensorName))
                .WithMessage("Sensor with this name already exists in this car system.");
        });

    }
}
