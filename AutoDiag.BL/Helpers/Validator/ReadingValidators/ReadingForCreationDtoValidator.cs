using AutoDiag.BL.DTOs.ReadingDTOs;
using AutoDiag.BL.Repositories;
using FluentValidation;


namespace AutoDiag.BL.Helpers.Validator.ReadingValidators;

public class ReadingForCreationDtoValidator : AbstractValidator<ReadingForCreationDto>
{
    public ReadingForCreationDtoValidator(
        ISensorRepository sensorRepository)
    {
        RuleSet("Input", () =>
        {
            // RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SensorId).NotEmpty();
        });

        RuleSet("Business", () =>
        {
            RuleFor(x => x.SensorId)
                .MustAsync(async (id, _) => await sensorRepository.SensorExistsAsync(id))
                .WithMessage("Sensor with this id does not exist.");
        });
    }
}
