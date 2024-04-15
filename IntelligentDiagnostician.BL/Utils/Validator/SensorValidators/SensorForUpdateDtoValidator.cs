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