using FluentValidation;
using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Repositories;

namespace IntelligentDiagnostician.BL.Utils.Validator.ReadingValidators;

public class ReadingForCreationDtoValidator : AbstractValidator<ReadingForCreationDto>
{
    public ReadingForCreationDtoValidator(
        ISensorRepository sensorRepository,
        ICarSystemRepository carSystemRepository)
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
        });
    }
}
