namespace IntelligentDiagnostician.BL.DTOs.ErrorDTOs;

public class ErrorForCreationDto
{
    public string ProblemCode { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
