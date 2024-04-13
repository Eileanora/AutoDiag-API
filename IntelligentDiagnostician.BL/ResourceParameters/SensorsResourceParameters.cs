namespace IntelligentDiagnostician.BL.ResourceParameters;

public class SensorsResourceParameters : BaseResourceParameters
{
    public SensorsResourceParameters()
    {
        OrderBy = "SensorName";
    }
    // filters
    public string? SensorName { get; set; }
}