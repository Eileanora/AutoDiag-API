namespace IntelligentDiagnostician.BL.Repositories;

public interface ITroubleCodeRepository
{
    Task<bool> ProblemCodeExistsAsync(string problemCode);
}
