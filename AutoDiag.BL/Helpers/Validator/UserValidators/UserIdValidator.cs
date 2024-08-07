﻿using FluentValidation;
using Microsoft.AspNetCore.Identity;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Helpers.Validator.UserValidators;

public class UserIdValidator : AbstractValidator<Guid>
{
    private readonly UserManager<AppUser> _userManager;

    public UserIdValidator(
        UserManager<AppUser> userManager)
    {
        RuleFor(x => x)
            .NotEmpty()
            .MustAsync(async (id, _) => await userManager.FindByIdAsync(id.ToString()) is not null)
            .WithMessage("User with this id does not exist.");
    }
}
