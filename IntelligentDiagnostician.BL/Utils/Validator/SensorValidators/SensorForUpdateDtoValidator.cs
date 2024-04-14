using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.Utils.Validator.SensorValidators;

public class SensorDtoForUpdateDtoValidator : AbstractValidator<SensorForUpdateDto>
{
    public SensorDtoForUpdateDtoValidator()
    {
        RuleSet("Input", () =>
        {
            RuleFor(s => s.SensorName).NameValidation();
        });
        // TODO: Implement the business rules
        RuleSet("Business", () =>
        {
            
        });
        
    }
}