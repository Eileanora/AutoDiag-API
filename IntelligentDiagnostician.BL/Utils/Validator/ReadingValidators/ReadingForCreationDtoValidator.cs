using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.AspNetCore.Identity;

namespace IntelligentDiagnostician.BL.Utils.Validator.ReadingValidators;

public class ReadingForCreationDtoValidator : AbstractValidator<ReadingForCreationDto>
{
    public ReadingForCreationDtoValidator(
        ISensorRepository sensorRepository,
        UserManager<AppUser> userManager)
    {
        RuleSet("Input", () =>
        {
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.SensorId).NotEmpty();
        });

        RuleSet("Business", () =>
        {
            RuleFor(x => x.SensorId)
                .MustAsync(async (id, _) => await sensorRepository.SensorExistsAsync(id))
                .WithMessage("Sensor with this id does not exist.");
            RuleFor(x => x.UserId)
                .MustAsync(async (id, _) => await userManager.FindByIdAsync(id.ToString()) is not null)
                .WithMessage("User with this id does not exist.");
        });
    }
}
