using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.BL.Helpers.Facades.CarSystemManagerFacade;
using FluentValidation;
using FluentValidation.Internal;
using AutoDiag.BL.Helpers.Converter;
namespace AutoDiag.BL.Manager.CarSystemManager;

public class CarSystemManager : ICarSystemManager
{
    private readonly ICarSystemManagerFacade _carSystemManagerFacade;
    public CarSystemManager(ICarSystemManagerFacade  carSystemManagerFacade)
    {
        _carSystemManagerFacade =  carSystemManagerFacade;
    }

    public async Task<PagedList<CarSystemDto>?> GetAllAsync(
        CarSystemsResourceParameters resourceParameters)
    {
        var systems = await  _carSystemManagerFacade
            .CarSystemRepository
            .GetAllAsync(resourceParameters);

        return systems.ToListDto();
    }

    public async Task<CarSystemDto?> GetByIdAsync(int id)
    {
        var system = await  _carSystemManagerFacade.CarSystemRepository.GetByIdAsync(id);
        if(system == null)
            return null;

        return system.ToDto();
    }

    public async Task<CarSystemDto?> CreateAsync(CarSystemForCreationDto systemForCreation)
    {
        var validationResult = await  _carSystemManagerFacade.CreationValidator.ValidateAsync(
            systemForCreation,
            options => options.IncludeRuleSets("Business"));
        
        if (!validationResult.IsValid)
        {
            // rollback transaction
            throw new ValidationException(validationResult.Errors);
        }

        var systemToCreate = systemForCreation.ToEntity();
        var createdSystem = await  _carSystemManagerFacade.CarSystemRepository.CreateAsync(systemToCreate);
        if (createdSystem == null)
            return null;
        await _carSystemManagerFacade.UnitOfWork.SaveAsync();
        return createdSystem.ToDto();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var system = await  _carSystemManagerFacade.CarSystemRepository.GetByIdAsync(id);
        if (system == null)
            return false;
        _carSystemManagerFacade.CarSystemRepository.Delete(system);
        await _carSystemManagerFacade.UnitOfWork.SaveAsync();
        return true;
    }
    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await  _carSystemManagerFacade.CarSystemRepository.CarSystemExistsAsync(id);
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

        var validationResult = await  _carSystemManagerFacade.UpdateValidator.ValidateAsync(context);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var system = await  _carSystemManagerFacade.CarSystemRepository.GetByIdAsync(systemId);
        systemForUpdate.UpdateEntity(system);
        _carSystemManagerFacade.CarSystemRepository.Update(system);
        await _carSystemManagerFacade.UnitOfWork.SaveAsync();
    }
}
