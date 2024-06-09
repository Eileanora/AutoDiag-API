using AutoDiag.BL.DTOs.FaultDTOs;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.BL.Manager.FaultManager;

public interface IFaultManager
{
    Task CreateAsync(
        Guid userId,
        List<string> errors);
    Task<PagedList<FaultDto>> GetAllAsync(
        FaultsResourceParameters readingResourceParameters);
    
}
