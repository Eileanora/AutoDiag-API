using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public class SensorForCreationDto
{
    public int Id { get; set; }
    public string SensorName { get; set; } = string.Empty;
    public float? MinValue { get; set; }
    public float? MaxValue { get; set; }
    public float? AvgValue { get; set; }
    public int CarSystemId { get; set; }
}
