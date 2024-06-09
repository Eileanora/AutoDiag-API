using AutoDiag.BL.ResourceParameters;
using AutoDiag.DataModels.Models;

namespace AutoDiag.BL.Repositories;

public interface IErrorRepository
{
    Task CreateAsync(Fault fault);
    Task<PagedList<Fault>> GetAllAsync(
        string userId,
        FaultsResourceParameters resourceParameters);
}