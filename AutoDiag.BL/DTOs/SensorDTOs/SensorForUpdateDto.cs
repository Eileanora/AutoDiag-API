using System.ComponentModel.DataAnnotations;

namespace AutoDiag.BL.DTOs.SensorDTOs;

public class SensorForUpdateDto
{
    public string? SensorName { get; set; }
    public float? MinValue { get; set; }
    public float? MaxValue { get; set; }
    public float? AvgValue { get; set; }
    public string? Unit { get; set; }
    public int? CarSystemId { get; set; }
}
