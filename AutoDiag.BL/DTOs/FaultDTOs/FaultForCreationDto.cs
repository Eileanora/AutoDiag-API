namespace AutoDiag.BL.DTOs.FaultDTOs;

public class FaultForCreationDto
{
    public string ProblemCode { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
