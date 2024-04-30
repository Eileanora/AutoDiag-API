using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface IErrorRepository
{
    Task CreateAsync(Error error);
    Task<PagedList<Error>> GetAllAsync(
        string userId,
        ErrorsResourceParameters resourceParameters);
}