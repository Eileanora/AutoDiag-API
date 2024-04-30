using FluentValidation;
using Microsoft.AspNetCore.Identity;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Utils.Validator.UserValidators;

public class UserIdValidator : AbstractValidator<Guid>
{
    private readonly UserManager<AppUser> _userManager;

    public UserIdValidator(UserManager<AppUser> userManager)
    {
        _userManager = userManager;

        RuleFor(x => x)
            .NotEmpty()
            .MustAsync(async (id, _) => await _userManager.FindByIdAsync(id.ToString()) is not null)
            .WithMessage("User with this id does not exist.");
    }
}
