namespace IntelligentDiagnostician.DataModels.Models;
public class Reading : BaseEntity
{
    public int ReadingValue { get; set;}
    public int SensorId { get; set; }
    public Sensor Sensor { get; set; }
     
    public AppUser User { get; set; }
}
