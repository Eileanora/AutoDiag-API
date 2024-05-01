using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface IErrorRepository
{
    Task CreateAsync(Fault fault);
    Task<PagedList<Fault>> GetAllAsync(
        string userId,
        FaultsResourceParameters resourceParameters);
}