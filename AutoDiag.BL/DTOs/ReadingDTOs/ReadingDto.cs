namespace AutoDiag.BL.DTOs.ReadingDTOs;

public class ReadingDto
{
    public int Id { get; set; }
    public float Value { get; set; }
    public float? MinValue { get; set; }
    public float? MaxValue { get; set; }
    public float? AvgValue { get; set; }
    public DateTime CreatedDate { get; set; }
}
