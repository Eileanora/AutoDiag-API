using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Utils.Converter;
using IntelligentDiagnostician.BL.Utils.Facades.ErrorManagerFacade;
using FluentValidation;

namespace IntelligentDiagnostician.BL.Manager.ErrorManager;

public class ErrorManager : IErrorManager
{
    private readonly IErrorManagerFacade _errorManagerFacade;
    public ErrorManager(IErrorManagerFacade errorManagerFacade)
    {
        _errorManagerFacade = errorManagerFacade;
    }
    
    public async Task CreateAsync(
        Guid userId,
        List<string> errors)
    {
        foreach (var error in errors)
        {
            var errorForCreationDto = new ErrorForCreationDto
            {
                UserId = userId,
                ProblemCode = error
            };
            
            var validationResult = await _errorManagerFacade.CreationValidator.ValidateAsync(
                errorForCreationDto,
                options => options.IncludeRuleSets("Business"));

            if (!validationResult.IsValid)
                continue;
            
            var newError = errorForCreationDto.ToError();
            await _errorManagerFacade.ErrorRepository
                .CreateAsync(newError);
        }

        await _errorManagerFacade.UnitOfWork.SaveAsync();
    }

    public async Task<PagedList<ErrorDto>> GetAllAsync(
        ErrorsResourceParameters resourceParameters)
    {
        var currentUserId = _errorManagerFacade
            .CurrentUserService.GetCurrentUser().UserId;
        
        if (currentUserId == Guid.Empty)
            throw new UnauthorizedAccessException("User is not authorized to access this resource");
        
        var errors = await  _errorManagerFacade
            .ErrorRepository
            .GetAllAsync(currentUserId.ToString(), resourceParameters);

        return errors.ToListDto();
    }
}
