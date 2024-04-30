using IntelligentDiagnostician.BL.DTOs.TroubleCodeDTOs;

namespace IntelligentDiagnostician.BL.DTOs.ErrorDTOs;

public class ErrorDto
{
    public int Id { get; set; }
    public string ProblemCode { get; set; } = string.Empty;
    public string ProblemDescription { get; set; } = string.Empty;
    public int? Severity { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<TroubleCodeLinkDto?> TroubleCodeLinks { get; set; } = new List<TroubleCodeLinkDto>();
}
