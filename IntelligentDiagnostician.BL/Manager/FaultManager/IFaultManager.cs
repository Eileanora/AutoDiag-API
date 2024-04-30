using IntelligentDiagnostician.BL.DTOs.FaultDTOs;
using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.BL.Manager.FaultManager;

public interface IFaultManager
{
    Task CreateAsync(
        Guid userId,
        List<string> errors);
    Task<PagedList<FaultDto>> GetAllAsync(
        FaultsResourceParameters readingResourceParameters);
    
}
