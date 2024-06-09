using AutoDiag.BL.DTOs.SensorDTOs;
using FluentValidation;
using AutoDiag.BL.Repositories;

namespace AutoDiag.BL.Utils.Validator.SensorValidators;

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



