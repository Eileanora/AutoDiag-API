using System.ComponentModel.DataAnnotations;

namespace AutoDiag.BL.DTOs.SensorDTOs;

public class SensorForCreationDto
{
    public int Id { get; set; }
    public string SensorName { get; set; } = string.Empty;
    public float? MinValue { get; set; }
    public float? MaxValue { get; set; }
    public float? AvgValue { get; set; }
    public string? Unit { get; set; }
    public int CarSystemId { get; set; }
}
