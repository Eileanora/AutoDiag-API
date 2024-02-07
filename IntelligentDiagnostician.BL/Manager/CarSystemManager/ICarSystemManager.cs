using IntelligentDiagnostician.BL.Dtos.CarSystemsDTOs;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Manager.CarSystemManager;

public interface ICarSystemManager
{
    Task<IEnumerable<CarSystemDto>> GetAllAsync();
    Task<CarSystemDtoWithSensors> GetById();
    // Task<CarSystemDtoWithSensors> GetByIdWithSensors();
}