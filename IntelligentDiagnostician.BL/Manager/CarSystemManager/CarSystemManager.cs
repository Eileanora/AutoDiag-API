using FluentValidation;
using FluentValidation.Internal;
using IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Utils.Facades.CarSystemManagerFacade;
using IntelligentDiagnostician.BL.Utils.Converter;
namespace IntelligentDiagnostician.BL.Manager.CarSystemManager;

public class CarSystemManager(ICarSystemManagerFacade carSystemManagerFacade) : ICarSystemManager
{

    public async Task<PagedList<CarSystemDto>?> GetAllAsync(
        CarSystemsResourceParameters resourceParameters)
    {
        var systems = await carSystemManagerFacade
            .CarSystemRepository
            .GetAllAsync(resourceParameters);

        return systems.ToListDto();
    }

    public async Task<CarSystemDto?> GetByIdAsync(int id)
    {
        var system = await carSystemManagerFacade.CarSystemRepository.GetByIdAsync(id);
        if(system == null)
            return null;

        return system.ToDto();
    }

    public async Task<CarSystemDto?> CreateAsync(CarSystemForCreationDto systemForCreation)
    {
        var validationResult = await carSystemManagerFacade.CreationValidator.ValidateAsync(
            systemForCreation,
            options => options.IncludeRuleSets("Business"));
        
        if (!validationResult.IsValid)
        {
            // rollback transaction
            throw new ValidationException(validationResult.Errors);
        }

        var systemToCreate = systemForCreation.ToEntity();
        var createdSystem = await carSystemManagerFacade.CarSystemRepository.CreateAsync(systemToCreate);
        if (createdSystem == null)
            return null;
        return createdSystem.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var system = await carSystemManagerFacade.CarSystemRepository.GetByIdAsync(id);
        if (system == null)
            return false;
        await carSystemManagerFacade.CarSystemRepository.DeleteAsync(system);
        return true;
    }
    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await carSystemManagerFacade.CarSystemRepository.CarSystemExistsAsync(id);
    }
    public async Task UpdateAsync(int systemId, CarSystemForUpdateDto systemForUpdate)
    {
        var context= new ValidationContext<CarSystemForUpdateDto>(
            systemForUpdate,
            new PropertyChain(),
            new RulesetValidatorSelector(new [] {"Business"}))
        {
            RootContextData =
            {
                ["systemId"] = systemId
            }
        };

        var validationResult = await carSystemManagerFacade.UpdateValidator.ValidateAsync(context);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var system = await carSystemManagerFacade.CarSystemRepository.GetByIdAsync(systemId);
        systemForUpdate.UpdateEntity(system);
        await carSystemManagerFacade.CarSystemRepository.UpdateAsync(system);
    }
}
