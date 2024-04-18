using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.BL.Repositories;

public interface IReadingRepository
{
    Task CreateAsync(Reading reading);
}