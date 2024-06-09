using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;

namespace AutoDiag.BL.Utils.Validator.FaultValidatiors;

public class FaultForCreationDtoValidator : AbstractValidator<FaultForCreationDto>
{
    public FaultForCreationDtoValidator(
        ITroubleCodeRepository troubleCodeRepository)
    {

        RuleSet("Business", () =>
        {
            RuleFor(x => x.ProblemCode)
                .MustAsync(async (problemCode, _) => await troubleCodeRepository
                    .ProblemCodeExistsAsync(problemCode))
                .WithMessage("TroubleCode doesn't exist.");
        });
    }
}
