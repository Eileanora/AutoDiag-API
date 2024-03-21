using IntelligentDiagnostician.BL.DTOs.Auditable;
using IntelligentDiagnostician.BL.DTOs.Auditable;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemDto : CarSystemBaseDto, IAuditable
{
    public int Id { get; set; }
    public IEnumerable<string>? Sensors { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
