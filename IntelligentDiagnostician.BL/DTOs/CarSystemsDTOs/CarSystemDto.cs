using System.Text.Json.Serialization;
using IntelligentDiagnostician.BL.DTOs.Auditable;
using IntelligentDiagnostician.BL.Utils.OrderedPropertiesJson;


namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

// [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<CarSystemDto>))]
public class CarSystemDto : CarSystemBaseDto, IAuditable
{
    public int Id { get; set; }
    public IEnumerable<string>? Sensors { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
