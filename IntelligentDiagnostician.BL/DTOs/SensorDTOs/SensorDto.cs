using IntelligentDiagnostician.BL.DTOs.Auditable;
namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public class SensorDto : SensorBaseDto , IAuditable
{
    public int Id { get; set; }
    public string? CarSystemName { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
