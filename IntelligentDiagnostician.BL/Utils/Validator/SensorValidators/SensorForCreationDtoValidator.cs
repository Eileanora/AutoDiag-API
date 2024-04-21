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
            RuleFor(s => s.Id).IdValidation();
            RuleFor(s => s.SensorName).NameValidation();
            RuleFor(s => s.MinValue)
                .LessThan(s => s.MaxValue)
                .WithMessage("Min value must be less than max value.")
                .When(s => s.MinValue != null && s.MaxValue != null);
            // Only apply this rule if both MinValue and MaxValue are not null

            RuleFor(s => s.MaxValue)
                .GreaterThan(s => s.MinValue)
                .WithMessage("Max value must be greater than min value.")
                .When(s => s.MinValue != null && s.MaxValue != null);
            // Only apply this rule if both MinValue and MaxValue are not null

            RuleFor(s => s.AvgValue)
                .Must((s, avgValue) => avgValue > s.MinValue && (s.MaxValue == null || avgValue < s.MaxValue))
                .WithMessage("Avg value must be between min and max values.")
                .When(s => s.AvgValue != null && s.MinValue != null);
            // Only apply this rule if AvgValue and MinValue are not null
        });
        RuleSet("Business", () =>
        {
            RuleFor(s => s.Id)
                .MustAsync(async (id, _) => !await sensorRepository.IsIdUniqueAsync(id))
                .WithMessage("Sensor with this id already exists.");
            RuleFor(s => s)
                .MustAsync(async (s, _)
                    => !await sensorRepository.IsNameUniqueAsync(s.CarSystemId, s.SensorName))
                .WithMessage("Sensor with this name already exists in this car system.");
        });
    }
}
