using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.BL.Utils.Facades.FaultManagerFacade;
using AutoDiag.BL.Utils.Converter;
using FluentValidation;

namespace AutoDiag.BL.Manager.FaultManager;

public class FaultManager : IFaultManager
{
    private readonly IFaultManagerFacade _faultManagerFacade;
    public FaultManager(IFaultManagerFacade faultManagerFacade)
    {
        _faultManagerFacade = faultManagerFacade;
    }
    
    public async Task CreateAsync(
        Guid userId,
        List<string> errors)
    {
        foreach (var error in errors)
        {
            var errorForCreationDto = new FaultForCreationDto
            {
                UserId = userId,
                ProblemCode = error
            };
            
            var validationResult = await _faultManagerFacade.CreationValidator.ValidateAsync(
                errorForCreationDto,
                options => options.IncludeRuleSets("Business"));

            if (!validationResult.IsValid)
                continue;
            
            var newError = errorForCreationDto.ToError();
            await _faultManagerFacade.ErrorRepository
                .CreateAsync(newError);
        }

        await _faultManagerFacade.UnitOfWork.SaveAsync();
    }

    public async Task<PagedList<FaultDto>> GetAllAsync(
        FaultsResourceParameters resourceParameters)
    {
        var currentUserId = _faultManagerFacade
            .CurrentUserService.GetCurrentUser().UserId;
        
        if (currentUserId == Guid.Empty)
            throw new UnauthorizedAccessException("User is not authorized to access this resource");
        
        var errors = await  _faultManagerFacade
            .ErrorRepository
            .GetAllAsync(currentUserId.ToString(), resourceParameters);

        return errors.ToListDto();
    }
}
