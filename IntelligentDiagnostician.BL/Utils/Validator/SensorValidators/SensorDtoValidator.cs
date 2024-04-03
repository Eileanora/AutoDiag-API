using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.SensorValidators;

public class SensorDtoValidator : AbstractValidator<SensorDto>
{
    public SensorDtoValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(s => s.SensorName).NameValidation();
    }
}



