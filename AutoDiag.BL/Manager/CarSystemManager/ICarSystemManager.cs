using AutoDiag.BL.DTOs.CarSystemsDTOs;
using AutoDiag.BL.ResourceParameters;

namespace AutoDiag.BL.Manager.CarSystemManager;

public interface ICarSystemManager
{
    Task<PagedList<CarSystemDto>?> GetAllAsync(
        CarSystemsResourceParameters resourceParameters);
    Task<CarSystemDto?> GetByIdAsync(int id);
    Task<CarSystemDto?> CreateAsync(CarSystemForCreationDto systemFor);
    Task<bool> DeleteAsync(int id);
    Task<bool> CarSystemExistsAsync(int id);
    Task UpdateAsync(int id, CarSystemForUpdateDto systemFor);
    //public Task<T> GetById<T>(int id, bool includeSensors) where T : BaseEntity;
}
