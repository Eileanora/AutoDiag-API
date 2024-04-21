using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.SensorValidators;

public class SensorDtoForUpdateDtoValidator : AbstractValidator<SensorForUpdateDto>
{
    public SensorDtoForUpdateDtoValidator(ISensorRepository sensorRepository)
    {
        RuleSet("Input", () =>
        {
            RuleFor(s => s.SensorName).NameValidation();
            RuleFor(s => s.MinValue)
                .LessThan(s => s.MaxValue)
                .WithMessage("Min value must be less than max value.")
                .When(s => s.MinValue != null && s.MaxValue != null);

            RuleFor(s => s.MaxValue)
                .GreaterThan(s => s.MinValue)
                .WithMessage("Max value must be greater than min value.")
                .When(s => s.MinValue != null && s.MaxValue != null);

            RuleFor(s => s.AvgValue)
                .Must((s, avgValue) => avgValue >= s.MinValue && (s.MaxValue == null || avgValue <= s.MaxValue))
                .WithMessage("Avg value must be between min and max values.")
                .When(s => s.AvgValue != null && s.MinValue != null);
        });
        RuleSet("Business", () =>
        {
            RuleFor(s => s)
                .MustAsync(async (s, _, context, cancellationToken) =>
                {
                    var existingSystem = await sensorRepository.GetByNameAsync(s.SensorName);
                    var sensorId = (int)context.RootContextData["sensorId"];
                    return existingSystem == null || existingSystem.Id == sensorId;
                })
                .WithMessage("SensorName already exists.");
        });
        
    }
}