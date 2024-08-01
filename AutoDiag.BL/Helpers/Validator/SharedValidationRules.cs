using FluentValidation;

namespace AutoDiag.BL.Helpers.Validator;

// Extension method for adding custom validation rules
public static class SharedValidationRules
{
    public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Name is required.")
            .Length(5, 20).WithMessage("Name must be more than 5 and less than 20 characters.");
    }
    
    public static IRuleBuilderOptions<T, int> IdValidation<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Id is required.");
    }
}
