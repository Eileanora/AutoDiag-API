using IntelligentDiagnostics.BL.Dtos.CarSystemsDTOs;
using IntelligentDiagnostics.DataModels.Models;

namespace IntelligentDiagnostics.BL.Manager.CarSystemManager;

public interface ICarSystemManager
{
    Task<IEnumerable<CarSystemDto>> GetAllAsync();
    Task<CarSystemDtoWithSensors> GetById();
    // Task<CarSystemDtoWithSensors> GetByIdWithSensors();
}