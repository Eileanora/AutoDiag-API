﻿using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DataModels.Models;


namespace IntelligentDiagnostician.BL.Repositories;

public interface ICarSystemRepository
{
    Task<bool> CarSystemExistsAsync(int id);
    Task<PagedList<CarSystem>> GetAllAsync(CarSystemsResourceParameters resourceParameters);
    new Task<CarSystem?> GetByIdAsync(int id);
    Task<CarSystem?> GetByNameAsync(string carSystemName);
    Task<bool> IsNameUnique(string carSystemName);
    Task<bool> IsNameUnique(int carSystemId, string carSystemName);
    Task <CarSystem> CreateAsync(CarSystem carSystem);
    // add all methods from the base repository class
    Task <CarSystem> UpdateAsync(CarSystem carSystem);
    Task DeleteAsync(CarSystem carSystem);
}