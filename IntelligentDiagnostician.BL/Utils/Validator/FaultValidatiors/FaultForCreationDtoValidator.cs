using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.FaultValidatiors;

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
