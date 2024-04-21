namespace IntelligentDiagnostician.BL.DTOs.ReadingDTOs;

public class ReadingDto
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public DateTime Date { get; set; }
    public double Value { get; set; }
}