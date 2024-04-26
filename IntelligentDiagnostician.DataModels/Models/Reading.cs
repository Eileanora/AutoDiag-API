namespace IntelligentDiagnostician.DataModels.Models;
public class Reading : PrimaryKeyBaseEntity
{
    // TODO: TEST AFTER MAKING FLOAT AND MAKE MIGIRATION
    public float Value { get; set;}
    public int SensorId { get; set; }
    public string UserId { get; set; }
    public string? Code { get; set; }
    public TroubleCode? TroubleCode { get; set; }
    public Sensor Sensor { get; set; }
    public AppUser User { get; set; }
}
