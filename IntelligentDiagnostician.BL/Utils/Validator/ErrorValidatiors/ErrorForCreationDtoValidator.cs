using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.ErrorValidatiors;

public class ErrorForCreationDtoValidator : AbstractValidator<ErrorForCreationDto>
{
    public ErrorForCreationDtoValidator(
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
