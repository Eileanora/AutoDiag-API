using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

namespace IntelligentDiagnostician.BL.Utils.Validator.CarSystemValidators;

public class CarSystemDtoValidator : AbstractValidator<CarSystemDto>
{
    public CarSystemDtoValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required.");
        RuleFor(x => x.CarSystemName).NameValidation();
    }
}





