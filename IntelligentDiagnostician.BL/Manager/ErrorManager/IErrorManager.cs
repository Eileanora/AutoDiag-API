using IntelligentDiagnostician.BL.DTOs.ErrorDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.BL.Manager.ErrorManager;

public interface IErrorManager
{
    Task CreateAsync(
        Guid userId,
        List<string> errors);
    Task<PagedList<ErrorDto>> GetAllAsync(
        ErrorsResourceParameters readingResourceParameters);
    
}
