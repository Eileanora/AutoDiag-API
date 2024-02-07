namespace IntelligentDiagnostician.DataModels.Models;
public class Reading : PrimaryKeyBaseEntity
{
    public int ReadingValue { get; set;}
    public int SensorId { get; set; }
    public Sensor Sensor { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
