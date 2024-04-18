namespace IntelligentDiagnostician.BL.Manager.ReadingManager;

public interface IReadingManager
{
    Task CreateAsync(int sensorId, Guid userId, int value);
}