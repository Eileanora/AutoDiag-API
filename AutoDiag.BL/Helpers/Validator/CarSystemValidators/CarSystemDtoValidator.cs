using AutoDiag.BL.DTOs.CarSystemsDTOs;
using FluentValidation;

namespace AutoDiag.BL.Helpers.Validator.CarSystemValidators;

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





