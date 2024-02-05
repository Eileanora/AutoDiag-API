namespace IntelligentDiagnostics.DataModels.Models;
public class Reading : PrimaryKeyBaseEntity
{
    public int ReadingValue { get; set;}
    public int CarSystemId { get; set; }
    public CarSystem CarSystem { get; set; }
    public int ParameterId { get; set; }
    public Sensor Sensor { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
